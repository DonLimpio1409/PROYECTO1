using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Eventos : MonoBehaviour
{
    [SerializeField] GameObject paredSubirEscaleras;
    [SerializeField] GameObject Presi1;
    [SerializeField] Animator mision1;
    [SerializeField] Animator mision2;

    [Header("Scripts")]
    DestruirPresi destruirPresi;
    DialogosNPCs dialogosNPCs;
    ControladorSFX controladorSFX;
    Jugador jugador;
    void Start()
    {
        dialogosNPCs = FindObjectOfType<DialogosNPCs>();
        controladorSFX = FindObjectOfType<ControladorSFX>();
        destruirPresi = FindObjectOfType<DestruirPresi>();
        jugador = FindObjectOfType<Jugador>();
    }

    // Update is called once per frame
    void Update()
    {
        PrimeraEscenaPresi();
        TutorialObjetos();
    }

    void PrimeraEscenaPresi()
    {
        if (dialogosNPCs.contadorPresi == 5)
        {
            controladorSFX.PrimerSonidoRuido();
        }
        if (dialogosNPCs.contadorPresi == 9)
        {
            Destroy(paredSubirEscaleras);
            mision1.SetBool("HaPasado", true);
            StartCoroutine(Esperar());
        }
        if (destruirPresi.destPresi == true)
        {
            Destroy(Presi1);
        }
    }

    void TutorialObjetos()
    {
        if (jugador.objcogidos >= 5)
        {
            mision2.SetBool("HaPasado", true);
            StartCoroutine(Esperar());
        }
    }

    IEnumerator Esperar()
    {
        yield return new WaitForSeconds(2f);
        mision1.SetBool("HaPasado", false);
        Destroy(mision1);
        mision2.SetBool("HaPasado", false);
    }
}