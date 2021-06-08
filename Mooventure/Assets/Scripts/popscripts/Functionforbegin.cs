using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Functionforbegin : MonoBehaviour
{

    [SerializeField] private GameObject window;
    [SerializeField] private GameObject parent;


    // Start is called before the first frame update
    public void create_pop_window()
    {
        Instantiate(window, parent.transform);
    }
    public void quitgame()
    {
        Application.Quit();
    }
}
