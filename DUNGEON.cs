using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DUNGEON : MonoBehaviour
{
    void OnCollisionEnter2D(Collision2D other)
    {
        CONTROLLER player = other.gameObject.GetComponent<CONTROLLER>();

        if (player.count >= 300)
        {
            Loader.Load(Loader.Scene.DUNGEON1);
        }
        else
        {
            Loader.Load(Loader.Scene.DUNGEON3);
        }

    }
}