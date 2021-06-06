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
    private IPlayerCommand Fire1;
    private IPlayerCommand Fire2;
    private IPlayerCommand Right;
    private IPlayerCommand Left;
    private IPlayerCommand Jump;

    private int window_done = 0;
    private float energy_time_count;

    // Start is called before the first frame update
    void Start()
    {
        speedref = MoveSpeed;
        this.gameObject.AddComponent<PlayerAttackCommand>();
        this.Fire1 = this.gameObject.GetComponent<PlayerAttackCommand>();
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

        if (this.transform.position.x >= this.goalBuilding.transform.position.x)
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
            Debug.Log("Ran into turkey!");
        }
        else if (collision.gameObject.tag == "ED")
        {
            Debug.Log("get drink");
            Destroy(collision.gameObject);
            MoveSpeed = MoveSpeed * 2.0f;
            energy_time_count = 5.0f;
        }
    }
}