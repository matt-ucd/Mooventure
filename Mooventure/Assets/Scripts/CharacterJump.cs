using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Player.Command;

namespace Player.Command
{
    public class CharacterJump : ScriptableObject, IPlayerCommand
    {
        // A speed will be assign at begining. This variable decide how high will captain jump.

        public void Execute(GameObject gameObject)
        {
            var rigidBody = gameObject.GetComponent<Rigidbody2D>();
            var jumpHeight = gameObject.GetComponent<PlayerController>().JumpHeight;
            if (rigidBody != null)
            {
                float hight = rigidBody.velocity.y;
                if (hight == 0.0f)
                {
                    rigidBody.velocity = new Vector2(rigidBody.velocity.x, jumpHeight);
                }
                // The jump function be achieved by given the captain a upward velocity.
                // The if statement will make sure captaion only can jump once. The captaion unable
                // to jump again befor he get back to the ground.
            }
        }
    }
}
