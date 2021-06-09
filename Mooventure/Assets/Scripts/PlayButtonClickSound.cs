using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayButtonClickSound : MonoBehaviour
{
    public AudioSource ClickSound;
    // public AudioSource TurkeySound;
    //public AudioSource EDSound;

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            this.ClickSound.Play();
            /* if(this.gameObject.tag == "Tutorial"){
                ClickSound.Play();
            } */
        }   
    }

    /* void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Turkey")
        {
            //TurkeySound.Play();
        }

        if (collision.gameObject.tag == "ED")
        {
            // EDSound.Play();
        }
    } */

    /* void OnGUI()
    {
        GUI.Label(audiorect, "Play Audio");
 
        if(audiorect.Contains(Event.current.mousePosition))
        {
            if(Input.GetMouseButtonDown(0))
            {
                clickSound.Play();
            }
        }
    } */

}
