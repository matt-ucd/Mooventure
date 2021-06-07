using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DontDestroyMapMusic : MonoBehaviour
{
   /*  public GameObject[] allBgMusic;
    public GameObject[] objs; */

    void Awake(){
        // Take out the background music for all the other scenes
        /* allBgMusic = GameObject.FindGameObjectsWithTag("All_Background_Music");
        Destroy(allBgMusic[0]); */
    
        GameObject[] intro_music = GameObject.FindGameObjectsWithTag("Intro_Background");
        GameObject[] level_music = GameObject.FindGameObjectsWithTag("Level_Background");

        if (intro_music.Length >= 1)
        {
            Destroy(intro_music[0]);
        }

        if (level_music.Length >= 1)
        {
            Destroy(level_music[0]);
        }
    }
}
