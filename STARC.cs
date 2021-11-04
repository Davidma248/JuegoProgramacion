using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class STARC : MonoBehaviour
{
    private Animator anim;

    public void Start()
    {
        anim = GetComponent<Animator>();
    }
    public void INICIO()
    {
        anim.SetTrigger("Start");
    }
}
