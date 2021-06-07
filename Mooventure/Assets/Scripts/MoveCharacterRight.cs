using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Player.Command;

namespace Player.Command
{
    public class MoveCharacterRight : ScriptableObject, IPlayerCommand
    {
        public void Execute(GameObject gameObject)
        {
            var rigidBody = gameObject.GetComponent<Rigidbody2D>();
            var speed = gameObject.GetComponent<PlayerController>().MoveSpeed;
            var playerController = gameObject.GetComponent<PlayerController>();
            if (rigidBody != null)
            {
                rigidBody.velocity = new Vector2(speed, rigidBody.velocity.y);
                if (!playerController.PlayerFacingRight())
                {
                    playerController.Flip();
                }
            }
        }
    }
}