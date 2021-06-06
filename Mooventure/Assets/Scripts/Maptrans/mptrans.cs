using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class mptrans : MonoBehaviour
{
    public void loatlevel1()
    {
        SceneManager.LoadScene(4);
    }
    public void backtodorm()
    {
        SceneManager.LoadScene(2);
    }
}
