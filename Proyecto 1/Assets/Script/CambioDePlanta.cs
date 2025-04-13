using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CambioDePlanta : MonoBehaviour
{
    [Header("Objetos")]
    [SerializeField] GameObject SubirBajar;
    [SerializeField] GameObject Jugador;

    private void OnTriggerEnter(Collider collision)
    { 
        if (collision.CompareTag("Jugador"))
        {
            CharacterController cc = Jugador.GetComponent<CharacterController>();

            if (cc != null)
            {
                cc.enabled = false;
            } 

            Jugador.transform.position = SubirBajar.transform.position;

            if (cc != null)
            {
                cc.enabled = true;
            }
        }

        //Cambiar la posicion del SubirBaja
    }
    
}
