using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Captain.Command;

namespace Captain.Command
{
    public class NormalWorkerPirateCommand : ScriptableObject, IPirateCommand
    {
        private float TotalWorkDuration;
        private float TotalWorkDone;
        private float CurrentWork;
        private const float PRODUCTION_TIME = 4.0f;
        private const float BASE_DURATION = 10.0f;
        private const float ITEM_VELOCITY_SCALAR = 4.0f;

        public void OnEnable()
        {
            // Randomize the total amount of time for pirate to work.
            TotalWorkDuration = BASE_DURATION + Random.value * BASE_DURATION;
        }

        public NormalWorkerPirateCommand()
        {
            // Set starting values for timers and exhausted status.
            this.CurrentWork = 0.0f;
            this.TotalWorkDone = 0.0f;
        }

        // Increment the timers based on time elapsed since last update.
        private void UpdateTimers()
        {
            this.CurrentWork += Time.deltaTime;
            this.TotalWorkDone += Time.deltaTime;
        }

        // Spawn the pirate's particular item. Used the code from the CommandPatternExample project
        // as the basis for spawning the items.
        private void SpawnItem(GameObject pirate, Object productPrefab)
        {
            var itemPosition = new Vector3(pirate.transform.position.x, pirate.transform.position.y, -0.01f);
            var item = (GameObject)Instantiate(productPrefab, itemPosition, pirate.transform.rotation);
            var itemRigidBody = item.GetComponent<Rigidbody2D>();
            itemRigidBody.velocity = new Vector2(Random.value * ITEM_VELOCITY_SCALAR, Random.value * ITEM_VELOCITY_SCALAR);
        }

        // Call function to increment timers, and then check them. Spawn an item if enough time has
        // elapsed. Return false if total elapsed time has exceeded maximum and put pirate into
        // exhausted state.
        public bool Execute(GameObject pirate, Object productPrefab)
        {
            this.UpdateTimers();

            if (this.TotalWorkDone < this.TotalWorkDuration)
            {
                if (this.CurrentWork >= PRODUCTION_TIME)
                {
                    this.SpawnItem(pirate, productPrefab);
                    this.CurrentWork = 0.0f;
                }

                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
