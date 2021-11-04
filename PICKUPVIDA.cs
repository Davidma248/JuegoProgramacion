using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PICKUPVIDA : MonoBehaviour
{
    public int HEAL;
    void OnCollisionEnter2D(Collision2D other)
    {
        CONTROLLER player = other.gameObject.GetComponent<CONTROLLER>();

        if (player != null)
        {
            player.TakeDamage(-(HEAL));
            Destroy(gameObject);
        }
    }
}
