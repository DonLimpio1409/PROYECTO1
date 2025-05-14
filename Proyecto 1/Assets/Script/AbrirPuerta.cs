using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbrirPuerta : MonoBehaviour
{
    Jugador ScrJugador;
    Animator animPuerta;

    bool puertaAbierta = false;
    void Start()
    {
        ScrJugador = FindObjectOfType<Jugador>();
        animPuerta = GetComponent<Animator>();
    }

    void Update()
    {
        if(ScrJugador.rayoAccionToca == true)
        {
            if(Input.GetKey(KeyCode.E) && puertaAbierta == false)
            {
                animPuerta.SetBool("Abrir",true);
                puertaAbierta = true;
            }
            else if(Input.GetKey(KeyCode.E) && puertaAbierta == true)
            {
                animPuerta.SetBool("Abrir",false);
                puertaAbierta = false;
            }
        }
    }
}
