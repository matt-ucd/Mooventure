using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Failwindowscript : MonoBehaviour
{

    private int trigger = 0;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (trigger == 1)
        {
            Time.timeScale = 1.0f;
            Destroy(this.gameObject);
        }
        else
        {
            Time.timeScale = 0.0f;
        }
    }

    public void restart()
    {
        trigger = 1;
        SceneManager.LoadScene(3);
    }

    public void quit()
    {
        trigger = 1;
        SceneManager.LoadScene(2);
    }
}
