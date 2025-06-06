using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Eventos : MonoBehaviour
{
    [SerializeField] GameObject paredSubirEscaleras;
    [SerializeField] GameObject presi1;
    [SerializeField] GameObject mision1;
    [SerializeField] GameObject mision2;
    [SerializeField] GameObject cajon;

    //Humos
    [SerializeField] GameObject humo;
    [SerializeField] GameObject humo1;
    [SerializeField] GameObject humo2;

    [Header("Scripts")]
    DestruirPresi destruirPresi;
    DialogosNPCs dialogosNPCs;
    ControladorSFX controladorSFX;
    Jugador jugador;
    SombrasCajon sombrasCajon;

    void Start()
    {
        dialogosNPCs = FindObjectOfType<DialogosNPCs>();
        controladorSFX = FindObjectOfType<ControladorSFX>();
        destruirPresi = FindObjectOfType<DestruirPresi>();
        jugador = FindObjectOfType<Jugador>();
        sombrasCajon = FindObjectOfType<SombrasCajon>();
    }

    // Update is called once per frame
    void Update()
    {
        PrimeraEscenaPresi();
        TutorialObjetos();
        DesplegarHumos();
    }

    void PrimeraEscenaPresi()
    {
        if (dialogosNPCs.contadorPresi == 5)
        {
            controladorSFX.PrimerSonidoRuido();
        }
        if (dialogosNPCs.contadorPresi == 9)
        {
            paredSubirEscaleras.transform.position = new Vector3(0, 0, 200);
            mision1.GetComponent<Animator>().SetBool("HaPasado", true);
            StartCoroutine(Esperar());
            dialogosNPCs.contadorPresi++;
        }
        if (destruirPresi.destPresi == true)
        {
            presi1.transform.position = new Vector3(0, 0, 200);
        }
    }

    void TutorialObjetos()
    {
        if (jugador.objcogidos == 5)
        {
            mision2.GetComponent<Animator>().SetBool("HaPasado", true);
            cajon.GetComponent<Animator>().SetBool("Abrir", true);
            StartCoroutine(Esperar());
            jugador.objcogidos++;
        }
    }

    void DesplegarHumos()
    {
        if (sombrasCajon.objOrganizados == 7)
        {
            humo.GetComponent<Animator>().SetBool("Ahumar", true);
            humo1.GetComponent<Animator>().SetBool("Ahumar", true);
            humo2.GetComponent<Animator>().SetBool("Ahumar", true);
        }
    }

    IEnumerator Esperar()
    {
        yield return new WaitForSeconds(2f);
        mision1.GetComponent<Animator>().SetBool("HaPasado", false);
        mision2.GetComponent<Animator>().SetBool("HaPasado", false);
    }
}