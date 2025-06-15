using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControladorEventos : MonoBehaviour
{
    [Header("Scripts")]
    Reloj ScrReloj;
    TpObjNpc ScrTpObjNpc;
    Jugador ScrJugador;

    [SerializeField] GameObject activadorNocheDia2;
    [SerializeField] GameObject ParedInvisible;
    [SerializeField] GameObject objetoDestruir;

    void Start()
    {
        ScrReloj = FindObjectOfType<Reloj>();
        ScrTpObjNpc = FindObjectOfType<TpObjNpc>();
        ScrJugador = FindObjectOfType<Jugador>();

  
    }

    void Update()
    {

    }
}
