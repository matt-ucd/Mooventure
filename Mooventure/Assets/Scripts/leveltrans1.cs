using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class leveltrans1 : MonoBehaviour
{
    public void back_to_dorm()
    {
        Time.timeScale = 1.0f;
        SceneManager.LoadScene(2);
    }
}
