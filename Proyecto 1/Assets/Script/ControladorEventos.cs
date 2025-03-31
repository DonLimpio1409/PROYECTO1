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
    [SerializeField] bool cogerPizza = false;

    void Start()
    {
        ScrReloj = FindObjectOfType<Reloj>();
        ScrTpObjNpc = FindObjectOfType<TpObjNpc>();
        ScrJugador = FindObjectOfType<Jugador>();

  
    }

    void Update()
    {
        NocheDia2();
    }

    void NocheDia2()
    {
        if (ScrReloj.hora == 22 && ScrReloj.minutos == 0 && ScrReloj.segundos < 1f)
        {
            activadorNocheDia2.SetActive(true);
            Debug.Log("ActivadorNocheDia2 activado.");
        }

        TpObjNpc scrDia2 = activadorNocheDia2.GetComponent<TpObjNpc>();
        GameObject pizza = GameObject.Find("pizza");

        // Suponemos que pizza existe y que scrDia2.usado es confiable
        if (ScrJugador.ObjMano == pizza && scrDia2.usado)
        {
            cogerPizza = true;
            ParedInvisible.SetActive(true);
            ParedInvisible.GetComponent<TpObjNpc>().puedeUsarse = true;
            
            
        }

        if (ScrJugador.rayoAccionToca && Input.GetMouseButton(1))
        {
            ScrJugador.ObjMano = null;
            ScrJugador.manoLlena = false;
            Destroy(objetoDestruir, 1f);
        }
    }
}
