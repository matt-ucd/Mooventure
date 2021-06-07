using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Player.Command;

public class PlayerController : MonoBehaviour
{
    public float MoveSpeed;
    public float JumpHeight;
    public float KnockbackForce;
    public float StunDuration;
    private float StunTimer;
    private IPlayerCommand Fire1;
    private IPlayerCommand Fire2;
    private IPlayerCommand Right;
    private IPlayerCommand Left;
    private IPlayerCommand Jump;

    // Start is called before the first frame update
    void Start()
    {
        this.gameObject.AddComponent<PlayerAttackCommand>();
        this.Fire1 = this.gameObject.GetComponent<PlayerAttackCommand>();
        //this.Fire2 = this.gameObject.GetComponent<CaptainCoinGun>();
        this.Jump = ScriptableObject.CreateInstance<CharacterJump>();
        this.Right = ScriptableObject.CreateInstance<MoveCharacterRight>();
        this.Left = ScriptableObject.CreateInstance<MoveCharacterLeft>();
        this.StunTimer = this.StunDuration;
    }

    void Knockback(Collision2D collision)
    {
        float direction;
        Vector2 knockbackVector;
        var playerRB = this.gameObject.GetComponent<Rigidbody2D>();

        if (collision.transform.position.x >= this.transform.position.x)
            direction = -1.0f;
        else
            direction = 1.0f;

        knockbackVector = new Vector2(this.KnockbackForce * direction, this.KnockbackForce);
        playerRB.velocity = Vector2.zero;
        playerRB.AddForce(knockbackVector, ForceMode2D.Impulse);
        this.gameObject.GetComponent<Animator>().SetBool("IsStunned", true);
        this.StunTimer = 0.0f;
    }

    // Update is called once per frame
    void Update()
    {
        var animator = this.gameObject.GetComponent<Animator>();
        if (this.StunTimer >= this.StunDuration)
        {
            animator.SetBool("IsStunned", false);

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
        }
        else
        {
            this.StunTimer += Time.deltaTime;
        }

        var playerVelocity = this.gameObject.GetComponent<Rigidbody2D>().velocity;
        animator.SetFloat("Velocity", Mathf.Abs(playerVelocity.x/5.0f));
        animator.SetFloat("VerticalVelocity", Mathf.Abs(playerVelocity.y));
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Turkey")
        {
            Debug.Log("Ran into turkey!");
            this.Knockback(collision);
        }
    }
}