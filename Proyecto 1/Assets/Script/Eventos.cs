using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Eventos : MonoBehaviour
{
    [SerializeField] GameObject paredSubirEscaleras;
    DialogosNPCs dialogosNPCs;
    ControladorSFX controladorSFX;

    void Start()
    {
        dialogosNPCs = FindObjectOfType<DialogosNPCs>();
        controladorSFX = FindObjectOfType<ControladorSFX>();
    }

    // Update is called once per frame
    void Update()
    {
        PrimeraEscenaPresi();
    }

    void PrimeraEscenaPresi()
    {
        if (dialogosNPCs.contadorPresi == 2)
        {
            dialogosNPCs.PuedeHablarLayla = true;
        }

        if (dialogosNPCs.contadorLayla == 2)
        {
            dialogosNPCs.PuedeHablarPresi = true;
        }

        if (dialogosNPCs.contadorPresi == 8)
        {
            Destroy(paredSubirEscaleras);
            dialogosNPCs.PuedeHablarLayla = true;
            Debug.Log("Layla tur");
        }
    }
}