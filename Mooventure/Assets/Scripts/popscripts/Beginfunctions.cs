using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Beginfunctions : MonoBehaviour
{
    
    public void notjump()
    {
        Destroy(this.gameObject);
        SceneManager.LoadScene(1);
    }
    public void jump()
    {
        Destroy(this.gameObject);
        SceneManager.LoadScene(2);
    }
}
