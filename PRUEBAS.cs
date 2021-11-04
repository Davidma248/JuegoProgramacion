using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PRUEBAS : MonoBehaviour
{
    void OnCollisionEnter2D(Collision2D other)
    {
        CONTROLLER player = other.gameObject.GetComponent<CONTROLLER>();

        Loader.Load(Loader.Scene.DUNGEON1);
    }
}
