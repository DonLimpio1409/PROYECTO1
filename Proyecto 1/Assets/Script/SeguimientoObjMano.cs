using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SeguimientoObjMano : MonoBehaviour
{
    Animator anim;

    void Start()
    {
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        float moverX = Input.GetAxis("Horizontal");
        float moverZ = Input.GetAxis("Vertical");

        if(moverX != 0 || moverZ != 0)
        {
            anim.SetBool("Handando", true);
        }
        else
        {
            anim.SetBool("Handando", false);
        }

    }
}
