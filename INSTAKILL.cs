using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class INSTAKILL : MonoBehaviour
{
    void OnCollisionEnter2D(Collision2D other)
    {
        CONTROLLER player = other.gameObject.GetComponent<CONTROLLER>();

        if (player != null)
        {
            player.TakeDamage(99);
        }
    }
}
