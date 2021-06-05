using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Captain.Command;

namespace Captain.Command
{
    // Captain ability to fire coin gun. Will launch a coin, which is deducted from coin total.
    public class CaptainCoinGun: MonoBehaviour, ICaptainCommand
    {
        private bool Active;
        private bool HasFired;
        private const float DURATION = 0.4f;
        private const float OFFSET = 0.2f;
        private const float COIN_POSITION_OFFSET = 2.0f;
        private const float COIN_VELOCITY_BASE = 5.0f;
        private const float COIN_VELOCITY_SCALAR = 2.0f;
        private float ElapsedTime;
        private GameObject Captain;
        private Object CoinPrefab;

        void Start()
        {
            this.ElapsedTime = 0.0f;
            this.Active = false;
        }

        // Check direction the captain is facing to get the coin direction.
        float GetCoinDirection(bool facingLeft)
        {
            if (facingLeft)
                return -1.0f;
            else
                return 1.0f;
        }

        // Calculate the velocity of the generated coin. The velocity of the captain is added to the coin to help prevent
        // the captain from collecting it as soon as it is fired. Added slight randomness to the velocity.
        void CoinVelocity(GameObject coin, float coinDirection, GameObject captain)
        {
            var captainVelocity = captain.GetComponent<Rigidbody2D>().velocity.x;
            var coinRigidBody = coin.GetComponent<Rigidbody2D>();
            coinRigidBody.velocity = new Vector2((COIN_VELOCITY_BASE + (Random.value * COIN_VELOCITY_SCALAR)) * coinDirection + captainVelocity, Random.value);
        }

        // Generate the coin and fire it.
        void FireCoin(GameObject captain)
        {
            bool facingLeft = captain.GetComponent<SpriteRenderer>().flipX;
            float coinDirection = this.GetCoinDirection(facingLeft);
            var coinPosition = new Vector3(captain.transform.position.x + COIN_POSITION_OFFSET * coinDirection, captain.transform.position.y, -0.01f);
            var coin = (GameObject)Instantiate(this.CoinPrefab, coinPosition, captain.transform.rotation);
            this.CoinVelocity(coin, coinDirection, captain);
        }

        void Update()
        {
            if (this.Active)
            {
                this.ElapsedTime += Time.deltaTime;
                if (this.ElapsedTime > OFFSET)
                {
                    // Check if a coin has been fired to avoid additional coins from also being fired.
                    if (!HasFired)
                    {
                        this.FireCoin(this.Captain);
                        this.HasFired = true;
                    }

                    if (this.ElapsedTime > DURATION || !this.Active)
                    {
                        this.Active = false;
                    }
                }
                this.Captain.GetComponent<Animator>().SetBool("IsShooting", this.Active);
            }
        }

        public void Execute(GameObject gameObject)
        {
            if(!this.Active)
            {
                this.ElapsedTime = 0.0f;
                this.Active = true;
                this.HasFired = false;
                this.Captain = gameObject;
                this.CoinPrefab = Resources.Load("Prefabs/Coin");
            }
        }

        public void Change_speed(int spd)
        {
            //Do nothing
        }
    }
}