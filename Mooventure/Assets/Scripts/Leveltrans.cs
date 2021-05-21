using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Leveltrans : MonoBehaviour
{
    public void Ln()
    {
        var currIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currIndex + 1);
    }
}
