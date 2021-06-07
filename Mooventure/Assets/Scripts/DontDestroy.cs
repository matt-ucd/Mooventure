using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DontDestroy : MonoBehaviour
{
    public GameObject[] objs;
    

    void Awake(){
        objs = GameObject.FindGameObjectsWithTag("Intro_Background");

        if (objs.Length <= 1) {
            DontDestroyOnLoad(objs[0]);
        } else {
            Destroy(objs[1]);
        }

    }
}
