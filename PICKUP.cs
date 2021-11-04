using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PICKUP : MonoBehaviour
{
    void OnEnter(CONTROLLER player)
    {
        Destroy(gameObject);
    }
}
