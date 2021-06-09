using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Showtext : MonoBehaviour
{
    private List<string> texts = new List<string>();
    private int list_size = 6;
    private int tract = 0;

    private int copy_loc = 0;
    private int copy_strlen;

    private float write = 0.0f;

    private string show;

    [SerializeField] float refresh_time = 0.5f;
    private bool complete = false;
    [SerializeField] Text CurrentText;

    // Start is called before the first frame update
    void Start()
    {
        texts.Add("Welcome to UC Davis!\nToday would be a great day to explore the campus. If you didn’t get much opportunity to visit the school in-person, this is the perfect virtual campus tour game to tour around our campus!");
        texts.Add("Are you ready?\nLet me give you a quick tutorial before you head off on a campus tour! ");
        texts.Add("You can click on the map to start your tour. When the map is opened, select a building level to start the game.");
        texts.Add("You can control your avatar to move (A or left arrow, D or right arrow), jump (space or right click), and attack (left click).");
        texts.Add("Be sure to watch out for obstacles, energy boosters on your tour as well.");
        texts.Add("Great! You are ready to go! Start the game anytime and I‘ll see you on the other side.");

        CurrentText.text = texts[0];
        complete = true;
    }

    // Update is called once per frame
    void Update()
    {
        write += Time.deltaTime;
        if (write >= refresh_time && complete == false && tract < list_size)
        {
            copy_strlen = texts[tract].Length;
            if (copy_loc < copy_strlen)
            {
                show += texts[tract][copy_loc];
                CurrentText.text = show;
                copy_loc++;
            }
            else
            {
                complete = true;
            }
            write = 0.0f;
        }

        if (Input.GetButtonDown("Fire1"))
        {
            if(complete == true && tract < list_size)
            {
                tract++;
                show = "";
                copy_loc = 0;
                complete = false;
            }
            else if (complete == false && tract < list_size)
            {
                CurrentText.text = texts[tract];
                complete = true;
            }

            if (tract >= list_size)
            {
                var currIndex = SceneManager.GetActiveScene().buildIndex;
                SceneManager.LoadScene(currIndex + 1);
            }
        }
    }
}
