    using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Eventos : MonoBehaviour
{
    [SerializeField] GameObject paredSubirEscaleras;
    [SerializeField] GameObject presi1;
    [SerializeField] GameObject mision1;
    [SerializeField] GameObject mision2;
    [SerializeField] GameObject mision3;
    [SerializeField] GameObject cajon;
    [SerializeField] GameObject humo;
    [SerializeField] GameObject itziarCubo;
    [SerializeField] GameObject puertaPasillo101;
    [SerializeField] GameObject puertaPasillo102;
    [SerializeField] GameObject Mario;
    [SerializeField] GameObject MarioDormido;
    [SerializeField] GameObject Javier;


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
        EscenaItziar();
        EscenaMarioSonambulo();
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
            controladorSFX.AbrirCajon();
            StartCoroutine(Esperar());
            jugador.objcogidos++;

            puertaPasillo101.transform.position = new Vector3(0f, 0f, 200f);
            puertaPasillo102.transform.position = new Vector3(0f, 0f, 200f);
        }
    }

    void EscenaItziar()
    {
        if (sombrasCajon.objOrganizados == 7)
        {
            StartCoroutine(Esperar1());
            humo.GetComponent<Animator>().SetBool("Ahumar", true);
            itziarCubo.transform.position = new Vector3(-323.8378f, 8.95f, -38.61416f);
        }
        if (dialogosNPCs.contadorItziar == 7)
        {
            humo.GetComponent<Animator>().SetBool("Ahumar", false);
            itziarCubo.transform.position = new Vector3(0f, 0f, 200f);
        }
    }

    void EscenaMarioSonambulo()
    {
        if (dialogosNPCs.habladoConPersonajes == 6)
        {
            //Setup
            mision3.GetComponent<Animator>().SetBool("HaPasado", true);
            //REPRODUCIR UN SONIDO DE RUIDO EN ESTA LINEA
            StartCoroutine(Esperar());
            Mario.SetActive(false);
            MarioDormido.SetActive(true);
            Javier.transform.position = new Vector3(-319.55f, 8.084f, -32.6f);
            Javier.transform.rotation = Quaternion.Euler(0, 166.89f, 0);
            Javier.tag = "Activable";
            dialogosNPCs.PuedeHablarJavier = true;
        }

        //Inicio del dialogo
        if (dialogosNPCs.contadorJavier == 11)
        {
            MarioDormido.tag = "Activable";
            dialogosNPCs.PuedeHablarMario = true;
        }
        if (dialogosNPCs.contadorMario == 9)
        {
            Javier.tag = "Activable";
            dialogosNPCs.PuedeHablarJavier = true;
        }
        if (dialogosNPCs.contadorJavier == 14)
        {
            MarioDormido.tag = "Activable";
            dialogosNPCs.PuedeHablarMario = true;
        }
        //Fin del dialogo
    }

    IEnumerator Esperar()
    {
        yield return new WaitForSeconds(4f);
        //Cuadros de mision
        mision1.GetComponent<Animator>().SetBool("HaPasado", false);
        mision2.GetComponent<Animator>().SetBool("HaPasado", false);
        mision2.GetComponent<Animator>().SetBool("HaPasado", false);
    }

    IEnumerator Esperar1()
    {
        yield return new WaitForSeconds(2f);
        //Cajon cerrar
        controladorSFX.CerrarCajon();
        cajon.GetComponent<Animator>().SetBool("Abrir", false);
    }
}   