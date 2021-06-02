using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseButtonScript : MonoBehaviour
{
    [SerializeField] private GameObject window;
    [SerializeField] private GameObject parent;

    public void create_window()
    {
        Instantiate(window, parent.transform);
    }
}

