using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Captain.Command;

namespace Captain.Command
{
    public class NormalWorkerPirateCommand : ScriptableObject, IPirateCommand
    {
        private float TotalWorkDuration; // 10-20 seconds in total - planned
        private float TotalWorkDone;    // how much time worked (compare with 10-20) - real
        private float CurrentWork;      // within the 4 seconds cycle, how much time spent (should produce 1 item or not)
        private const float PRODUCTION_TIME = 4.0f; // produce 1 item each 4 seconds


        public void OnEnable()
        {
            // initialize TotalWorkDuration
            this.TotalWorkDuration = Random.value * 10.0f + 10.0f;
        }

        public NormalWorkerPirateCommand()
        {
            // initialize
            this.TotalWorkDone = 0.0f;
            this.CurrentWork = 0.0f;
        }

        public bool Execute(GameObject pirate, Object productPrefab)
        {
            // Update TotalWorkDone and CurrentWork each frame
            this.TotalWorkDone += Time.deltaTime;
            this.CurrentWork += Time.deltaTime;
            
            //This function returns false when no work is done. 
            //After you implement work according to the specification and
            //generate instances of productPrefab, this function should return true.
            
            // Already worked for the assigned amount of time
            if (this.TotalWorkDuration <= this.TotalWorkDone)
            {
                return false;
            } 
            else
            {
                // only when after each PRODUCTION_TIME duration, the new gameObject is instantiated
                if (this.CurrentWork >= PRODUCTION_TIME)
                {
                    // instantiate the prefab
                    var mushroom = (GameObject)Instantiate(productPrefab, pirate.transform.localPosition, pirate.transform.rotation);
                    
                    // set Rigidbody2D values
                    var mushroomRigidBody = mushroom.GetComponent<Rigidbody2D>();
                    mushroomRigidBody.velocity = mushroom.transform.forward * 50f;  // throw speed
                    mushroomRigidBody.AddForce(new Vector2(Random.value, Random.value) * 260.0f);   // force to throw out the prefab
                    mushroom.transform.position = new Vector2(pirate.transform.position.x, pirate.transform.position.y);    // start position of the throw
                    this.CurrentWork = 0.0f;    // after a prefab is made, CurrentWork is reset to 0 (start a new cycle)
                    return true;
                }
                else 
                {
                    // when a single production cycle has not finished yet
                    return true;
                }
            }   
        }
    }
}
