using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DontDestroyLevelMusic : MonoBehaviour
{
   /*  public GameObject[] allBgMusic;
    public GameObject[] objs; */

    void Awake(){
        // Take out the background music for all the other scenes
        /* allBgMusic = GameObject.FindGameObjectsWithTag("All_Background_Music");
        Destroy(allBgMusic[0]); */
    

        GameObject[] intro_music = GameObject.FindGameObjectsWithTag("Intro_Background");
        GameObject[] map_music = GameObject.FindGameObjectsWithTag("Map_Background");

        if (intro_music.Length >= 1)
        {
            Destroy(intro_music[0]);
        }

        if (map_music.Length >= 1)
        {        
            Destroy(map_music[0]);

        }
        
    }
}
