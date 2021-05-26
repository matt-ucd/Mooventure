/*
 * This is the script for all 3 enemies.
 * 
 * Enemy continue to walk and run in each background
 * back and forth at a pseudo-random given speed.
 * 
 * Bounds are set near the position of the transition bombs
 * in which the enemy will turn around and move when get closer
 * to the bomb.
 *
 * */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyIdling : MonoBehaviour
{
    private Rigidbody2D rb;
    private float Speed;
    private float Bounds = 16.0f;
    private bool isLeft;    // bool variable to show if it is moving to the left

    private float positionX;
    private float positionY;

    // Start is called before the first frame update
    void Start()
    {
        // To make it more interesting, the 3 speed of enemies
        // in the 3 background are randomly decided.
        var chooseSpeed = Random.Range(1,4);
        if (chooseSpeed == 1)
        {
            Speed = 4.0f;
        }
        else if (chooseSpeed == 2)
        {
            Speed = 7.0f;
        }
        else
        {
            Speed = 1.0f;
        }
        
        // more initialize on starting positions
        rb = GetComponent<Rigidbody2D>();
        positionX = transform.position.x;
        positionY = transform.position.y;
        // go to left first
        rb.velocity = new Vector2(-this.Speed, rb.velocity.y);
        GetComponent<SpriteRenderer>().flipX = true;
        isLeft = true;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        // update current position each time
        positionX = transform.position.x;
        positionY = transform.position.y;
        
        // Assign desire moving direction and movement
        if (positionX > -Bounds && positionX <= Bounds)
        {
            // continue going in the same direction
            if (!isLeft) // go right
            {
                rb.velocity = new Vector2(this.Speed, rb.velocity.y);
                GetComponent<SpriteRenderer>().flipX = false;
            }
            else    // go left
            {
                rb.velocity = new Vector2(-this.Speed, rb.velocity.y);
                GetComponent<SpriteRenderer>().flipX = true;
            }
        }
        else if (positionX <= -Bounds)
        {
            // change direction -> go right
            rb.velocity = new Vector2(this.Speed, rb.velocity.y);
            GetComponent<SpriteRenderer>().flipX = false;
            isLeft = false;
        }
        else if (positionX >= Bounds)
        {
            // change direction -> go left
            rb.velocity = new Vector2(-this.Speed, rb.velocity.y);
            GetComponent<SpriteRenderer>().flipX = true;
            isLeft = true;
        }
    }

}
