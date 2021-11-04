using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MENU: MonoBehaviour
{
    public float Delay = 1;

    public void Play()
    {
        Invoke("Amogus", Delay);
    }

    public void Amogus()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}