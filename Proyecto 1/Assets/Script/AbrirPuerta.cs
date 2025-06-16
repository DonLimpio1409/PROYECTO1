using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbrirPuerta : MonoBehaviour
{   //hjk 
    Jugador ScrJugador;
    Animator ScrAnimPuerta;
    ControladorSFX ScrControladorSFX;
    
    bool puertaAbierta = false;
    void Start()
    {
        ScrJugador = FindObjectOfType<Jugador>();
        ScrControladorSFX = FindObjectOfType<ControladorSFX>();

    }

    void Update()
    {
        if(ScrJugador.rayoAccionToca == true)
        {
            if(Input.GetKeyDown(KeyCode.E) && ScrJugador.rayoTocando.collider.gameObject.layer == LayerMask.NameToLayer("Puerta"))
            {
                ScrAnimPuerta = ScrJugador.rayoTocando.collider.gameObject.GetComponent<Animator>();

                if (puertaAbierta == false)
                {
                    ScrControladorSFX.SonidoAbrePuerta();
                    ScrAnimPuerta.SetBool("Abrir", true);
                    puertaAbierta = true;
                }
                else
                {
                    ScrControladorSFX.SonidoCierraPuerta();
                    ScrAnimPuerta.SetBool("Abrir", false);
                    puertaAbierta = false;
                }
            }
        }
    }
}
