using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Introscript : MonoBehaviour
{
    public void startgame()
    {
        SceneManager.LoadScene(3);
    }
    public void watchintro()
    {
        SceneManager.LoadScene(1);
    }
}