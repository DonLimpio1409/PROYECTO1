using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControladorEventos : MonoBehaviour
{
    [Header("Scripts")]
    Reloj ScrReloj;
    TpObjNpc ScrTpObjNpc;
    

    [SerializeField] GameObject activadorNocheDia2;
    [SerializeField] GameObject activadorNocheDia2Ismael;

    void Start()
    {
        ScrReloj = FindObjectOfType<Reloj>();
        ScrTpObjNpc = FindObjectOfType<TpObjNpc>();
        
    }

    void Update()
    {
        NocheDia2();
    }

    void NocheDia2()
    {
        // Verifica la hora, minuto y si los segundos son menores a 1 (es decir, entre 0 y 1)
        if (ScrReloj.hora == 22 && ScrReloj.minutos == 0 && ScrReloj.segundos < 1f)
        {
            if (activadorNocheDia2 != null)
            {
                activadorNocheDia2.SetActive(true);
                Debug.Log("ActivadorNocheDia2 activado.");
            }          
        }

        TpObjNpc scrDia2 = activadorNocheDia2.GetComponent<TpObjNpc>();
        if (scrDia2 != null && scrDia2.usado == true && ScrReloj.hora == 23 && ScrReloj.minutos == 0 && ScrReloj.segundos < 1f)
        {
            activadorNocheDia2Ismael.SetActive(true);
        }

        

    }
}
