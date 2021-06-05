using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurkeyController : MonoBehaviour
{
    [SerializeField] private float AggroDistance;
    [SerializeField] private float AggroDropDistance;
    [SerializeField] private float IdleDistance;
    [SerializeField] private float AggroSpeed;
    [SerializeField] private float IdleSpeed;
    private Vector3 PlayerPosition;
    private Vector3 TurkeyPosition;
    private Rigidbody2D TurkeyRB;
    private float FleePointX;
    private float SpawnPointX;
    private float LeftAggroBound;
    private float LeftIdleBound;
    private float RightAggroBound;
    private float RightIdleBound;
    private int Direction = 1;
    //private bool IsFacingLeft;
    private bool IsAggro = false;
    private bool IsFleeing = false;

    void Start()
    {
        this.transform.rotation = Quaternion.Euler(0, 0, 0); // lock rotation
        this.SpawnPointX = this.transform.position.x;
        this.LeftIdleBound = this.SpawnPointX - this.IdleDistance;
        this.RightIdleBound = this.SpawnPointX + this.IdleDistance;
        this.LeftAggroBound = this.SpawnPointX - this.AggroDistance;
        this.RightAggroBound = this.SpawnPointX + this.AggroDistance;
        this.TurkeyRB = gameObject.GetComponent<Rigidbody2D>();
    }

    void IdleTurkey()
    {
        if (this.TurkeyPosition.x <= LeftIdleBound)
        {
            this.Direction = 1;
            //this.IsFacingLeft = false;
            GetComponent<SpriteRenderer>().flipX = true;
        }
        else if (this.TurkeyPosition.x >= RightIdleBound)
        {
            this.Direction = -1;
            //this.IsFacingLeft = true;
            GetComponent<SpriteRenderer>().flipX = false;
        }

        this.TurkeyRB.velocity = new Vector2(this.IdleSpeed * this.Direction, this.TurkeyRB.velocity.y);
    }

    void AggroTurkey()
    {
        if (this.TurkeyPosition.x > this.PlayerPosition.x)
        {
            this.Direction = -1;
            //this.IsFacingLeft = true;
            GetComponent<SpriteRenderer>().flipX = false;
        }
        else if (this.TurkeyPosition.x < this.PlayerPosition.x)
        {
            this.Direction = 1;
            //this.IsFacingLeft = false;
            GetComponent<SpriteRenderer>().flipX = true;
        }

        this.TurkeyRB.velocity = new Vector2(this.AggroSpeed * this.Direction, this.TurkeyRB.velocity.y);
    }

    void FleeingTurkey()
    {
        if (this.TurkeyPosition.x >= this.PlayerPosition.x)
        {
            this.Direction = 1;
            GetComponent<SpriteRenderer>().flipX = true;
        }
        else
        {
            this.Direction = -1;
            GetComponent<SpriteRenderer>().flipX = false;
        }

        this.TurkeyRB.velocity = new Vector2(this.AggroSpeed * this.Direction, this.AggroSpeed);
    }

    public void Damaged()
    {
        Debug.Log("Turkey runs away!");
        this.FleePointX = this.transform.position.x;
        this.IsFleeing = true;
        this.GetComponent<Animator>().SetTrigger("Damaged");
    }

    void Update()
    {
        this.transform.rotation = Quaternion.Euler(0, 0, 0); // lock rotation
        this.TurkeyPosition = this.transform.position;
        this.PlayerPosition = GameObject.Find("Player").transform.position;

        if (Vector3.Distance(this.TurkeyPosition, this.PlayerPosition) <= this.AggroDistance)
        {
            this.IsAggro = true;
            this.GetComponent<Animator>().SetBool("IsAggro", true);
        }

        if (Vector3.Distance(this.TurkeyPosition, this.PlayerPosition) >= this.AggroDropDistance)
        {
            this.IsAggro = false;
            this.GetComponent<Animator>().SetBool("IsAggro", false);
        }

        if (this.IsFleeing)
        {
            this.FleeingTurkey();
        }
        else
        {
            if (this.IsAggro)
            {
                this.AggroTurkey();
            }
            else
            {
                this.IdleTurkey();
            }
        }
    }
}