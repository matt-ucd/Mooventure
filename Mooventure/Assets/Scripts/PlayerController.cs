using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Player.Command;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private GameObject window;
    [SerializeField] private GameObject parent;
    [SerializeField] private GameObject goalBuilding;

    public float MoveSpeed;
    private float speedref;
    public float JumpHeight;
    public float KnockbackForce;
    public float StunDuration;
    private bool isFacingRight;
    private float StunTimer;
    private IPlayerCommand Fire1;
    private IPlayerCommand Fire2;
    private IPlayerCommand Right;
    private IPlayerCommand Left;
    private IPlayerCommand Jump;

    private int window_done = 0;
    private float energy_time_count;


    // public AudioSource TurkeySound;

    // Start is called before the first frame update
    void Start()
    {
        speedref = MoveSpeed;
        this.gameObject.AddComponent<PlayerAttackCommand>();
        this.Fire1 = this.gameObject.GetComponent<PlayerAttackCommand>();
        this.Fire2 = ScriptableObject.CreateInstance<CharacterJump>();
        this.Jump = ScriptableObject.CreateInstance<CharacterJump>();
        this.Right = ScriptableObject.CreateInstance<MoveCharacterRight>();
        this.Left = ScriptableObject.CreateInstance<MoveCharacterLeft>();
        this.StunTimer = this.StunDuration;
        this.isFacingRight = true;
        // TurkeySound = GetComponent<AudioSource>();
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

        if (this.energy_time_count > 0.1)
            this.energy_time_count = 0.1f;
    }

    public bool PlayerFacingRight()
    {
        return this.isFacingRight;
    }

    public void Flip()
    {
        this.isFacingRight = !this.isFacingRight;

        this.transform.Rotate(0.0f, 180.0f, 0.0f);
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
                this.Fire2.Execute(this.gameObject);
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

        // if the player reaches the place before the goal building 5 units far, finish the level
        if (this.transform.position.x >= this.goalBuilding.transform.position.x - 5.0f)
        {
            if (window_done == 0)
            {
                Instantiate(window, parent.transform);
                window_done = 1;
                Time.timeScale = 0.0f;
            }
        }
        Debug.Log("Time is " + energy_time_count);
        if (energy_time_count > 0)
        {
            Debug.Log("Stop here");
            energy_time_count -= Time.deltaTime;
            if (energy_time_count <= 0.1f)
            {
                MoveSpeed = speedref;
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Turkey")
        {
            SoundManagerScript.PlaySound("level-turkey-gobble");
            Debug.Log("Ran into turkey!");
            this.Knockback(collision);
        }
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.tag == "ED")
        {
            SoundManagerScript.PlaySound("level-get-energy");
            Debug.Log("get drink");
            Destroy(collider.gameObject);
            if(MoveSpeed < speedref * 2)
            {
                MoveSpeed = MoveSpeed * 2.0f;
            }
            energy_time_count = 5.0f;
        }
    }
}