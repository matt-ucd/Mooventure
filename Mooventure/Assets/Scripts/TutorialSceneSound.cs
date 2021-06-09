using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialSceneSound : MonoBehaviour
{
    public AudioSource ClickSound;
    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            this.ClickSound.Play();
        }   
    }
}