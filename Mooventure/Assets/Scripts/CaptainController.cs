using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Captain.Command;

public class CaptainController : MonoBehaviour
{
    [SerializeField] private GameObject window;
    [SerializeField] private GameObject parent;

    private ICaptainCommand Fire1;
    private ICaptainCommand Fire2;
    private ICaptainCommand Right;
    private ICaptainCommand Left;
    private ICaptainCommand Jump;
    private const int MUSHROOM_VALUE = 1;
    private const int SKULL_VALUE = 2;
    private const int GEM_VALUE = 3;
    private int window_done = 0;
    //private float pushAmount = 0;

    public UnityEngine.UI.Text Booty;
    public int Mushrooms;
    public int Skulls;
    public int Gems;
    public int Coins;
    //public float libPositionX;
    public float goalMarkPositionX;

    // Start is called before the first frame update
    void Start()
    {
        this.transform.rotation = Quaternion.Euler(0, 0, 0); // lock rotation
        this.gameObject.AddComponent<CaptainMotivateCommand>();
        this.gameObject.AddComponent<CaptainCoinGun>();
        this.Fire1 = this.gameObject.GetComponent<CaptainMotivateCommand>();
        this.Fire2 = this.gameObject.GetComponent<CaptainCoinGun>();
        this.Jump = ScriptableObject.CreateInstance<CharacterJump>();
        this.Right = ScriptableObject.CreateInstance<MoveCharacterRight>();
        this.Left = ScriptableObject.CreateInstance<MoveCharacterLeft>();
        //this.Booty.text = "Booty";
    }

    // Update is called once per frame
    void Update()
    {
        this.transform.rotation = Quaternion.Euler(0, 0, 0); // lock rotation
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
            if (this.Coins > 0)
            {
                // Check if captain is still in coin gun animation to avoid deducting more
                // than one coin per shot.
                if (!this.gameObject.GetComponent<Animator>().GetBool("IsShooting"))
                {
                    this.Fire2.Execute(this.gameObject);
                    this.Coins--;
                }
            }
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
        animator.SetFloat("Velocity", Mathf.Abs(this.gameObject.GetComponent<Rigidbody2D>().velocity.x/5.0f));
        //this.Booty.text = "x" + Coins;

        if (this.transform.position.x >= this.goalMarkPositionX)
        {
            if(window_done == 0)
            {
                Instantiate(window, parent.transform);
                window_done = 1;
                Time.timeScale = 0.0f;
            }
        }
    }

    // Updated the collection system. The number of mushrooms, skulls, and gems will still
    // be tracked, but now coins will be counted separately. The value of each collected
    // item will remain. This was changed to facilitate the coin gun feature.
    private void OnCollisionEnter2D(Collision2D collision)
    {
        //Debug.Log(collision);
        if (collision.gameObject.tag == "Mushroom")
        {
            Destroy(collision.gameObject);
            this.Mushrooms++;
            this.Coins += MUSHROOM_VALUE;
        }
        else if (collision.gameObject.tag == "Skull")
        {
            Destroy(collision.gameObject);
            this.Skulls++;
            this.Coins += SKULL_VALUE;
        }
        else if (collision.gameObject.tag == "Gem")
        {
            Destroy(collision.gameObject);
            this.Gems++;
            this.Coins += GEM_VALUE;
        }
        else if (collision.gameObject.tag == "Coin")
        {
            // Added coins as an object in which the captain can collide.
            Destroy(collision.gameObject);
            this.Coins++;
        }
        else if (collision.gameObject.tag == "Turkey")
        {
            Debug.Log("Ran into turkey!");
        }
        else if (collision.gameObject.tag == "Goal_Mark")
        {
            Instantiate(window, parent.transform);
        }
    }
}