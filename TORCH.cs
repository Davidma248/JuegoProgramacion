using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TORCH : MonoBehaviour
{
    void OnCollisionEnter2D(Collision2D other)
    {
        CONTROLLER player = other.gameObject.GetComponent<CONTROLLER>();

        if(player.count >= 500)
        {
            Loader.Load(Loader.Scene.DUNGEON2);
        }
        else
        {
            Loader.Load(Loader.Scene.DUNGEON1);
        }

    }
}
