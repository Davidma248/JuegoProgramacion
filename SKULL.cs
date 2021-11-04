using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SKULL : MonoBehaviour
{
    void OnCollisionEnter2D(Collision2D other)
    {
        CONTROLLER player = other.gameObject.GetComponent<CONTROLLER>();

        if (player.count >= 700)
        {
            Loader.Load(Loader.Scene.MENU);
        }
        else
        {
            Loader.Load(Loader.Scene.DUNGEON2);
        }

    }
}