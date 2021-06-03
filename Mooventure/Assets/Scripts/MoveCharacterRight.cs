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
            if (rigidBody != null)
            {
                rigidBody.velocity = new Vector2(speed, rigidBody.velocity.y);
                gameObject.GetComponent<SpriteRenderer>().flipX = false;
            }
        }
    }
}