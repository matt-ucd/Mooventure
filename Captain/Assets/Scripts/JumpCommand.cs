/*
 * This is the script for "Fire2" - Jump.
 * 
 * The Captain can jump whenever the mouse is right clicked.
 * 
 * To make the game more interesting and make the "jump" more
 * meaningful, enemies are added to be continuously walking 
 * in all the backgrounds. The Captain will lose a coin if 
 * he is collided with the enemy, so the player need to "jump" 
 * to avoid hitting enemies.
 * See "EnemyIdling.cs" for more details about the enemy.
 * 
 * */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Captain.Command;

namespace Captain.Command
{
    public class JumpCommand : ScriptableObject, ICaptainCommand
    {
        private Rigidbody2D rb;

        public void Execute(GameObject gameObject)
        {
            rb = gameObject.GetComponent<Rigidbody2D>();
            // just jump straight up
            rb.velocity = new Vector2(rb.velocity.x, 22.0f);

        }
    }
}