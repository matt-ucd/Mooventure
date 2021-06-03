using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Player.Command;

public class PlayerController : MonoBehaviour
{
    public float MoveSpeed;
    public float JumpHeight;
    private IPlayerCommand Fire1;
    private IPlayerCommand Fire2;
    private IPlayerCommand Right;
    private IPlayerCommand Left;
    private IPlayerCommand Jump;

    // Start is called before the first frame update
    void Start()
    {
        //this.Fire1 = this.gameObject.GetComponent<CaptainMotivateCommand>();
        //this.Fire2 = this.gameObject.GetComponent<CaptainCoinGun>();
        this.Jump = ScriptableObject.CreateInstance<CharacterJump>();
        this.Right = ScriptableObject.CreateInstance<MoveCharacterRight>();
        this.Left = ScriptableObject.CreateInstance<MoveCharacterLeft>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            this.Fire1.Execute(this.gameObject);
        }
        if (Input.GetButtonDown("Jump"))
        {
            this.Jump.Execute(this.gameObject);
        }
        if (Input.GetButtonDown("Fire2"))
        {
        }
        if (Input.GetAxis("Horizontal") > 0.01)
        {
            this.Right.Execute(this.gameObject);
        }
        if (Input.GetAxis("Horizontal") < -0.01)
        {
            this.Left.Execute(this.gameObject);
        }

        var animator = this.gameObject.GetComponent<Animator>();
        var playerVelocity = this.gameObject.GetComponent<Rigidbody2D>().velocity;
        animator.SetFloat("Velocity", Mathf.Abs(playerVelocity.x/5.0f));
        animator.SetFloat("VerticalVelocity", Mathf.Abs(playerVelocity.y));
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Turkey")
        {
            Debug.Log("Ran into turkey!");
        }
    }
}