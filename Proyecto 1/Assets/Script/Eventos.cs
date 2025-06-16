    using System.Collections;
using System.Collections.Generic;
using Palmmedia.ReportGenerator.Core.Reporting.Builders;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.AI;
using Unity.VisualScripting;

public class Eventos : MonoBehaviour
{
    [SerializeField] GameObject paredSubirEscaleras;
    [SerializeField] GameObject presi1;
    [SerializeField] GameObject mision1;
    [SerializeField] GameObject mision2;
    [SerializeField] GameObject mision3;
    [SerializeField] GameObject mision4;
    [SerializeField] GameObject mision5;
    [SerializeField] GameObject mision6;
    [SerializeField] GameObject cajon;
    [SerializeField] GameObject humo;
    [SerializeField] GameObject itziarCubo;
    [SerializeField] GameObject puertaPasillo101;
    [SerializeField] GameObject puertaPasillo102;
    [SerializeField] GameObject caja;
    [SerializeField] GameObject cama;
    [SerializeField] GameObject notaItziar;
    [SerializeField] GameObject ordenadorPaul;
    [SerializeField] GameObject DestructorPaul;
    [SerializeField] GameObject fondoCopiar;
    [SerializeField] GameObject puzlePaul;
    [SerializeField] GameObject sistemaParticulas;
    [SerializeField] GameObject mazo;
    [SerializeField] GameObject extintorRoto;
    [SerializeField] GameObject extintorNormal;
    [SerializeField] GameObject movil;
    [SerializeField] GameObject LanzadorEscena;


    [Header("Personajes")]
    [SerializeField] GameObject Layla;
    [SerializeField] GameObject Mario;
    [SerializeField] GameObject Javier;
    [SerializeField] GameObject Isma;
    [SerializeField] GameObject Paul;
    [SerializeField] GameObject Nestor;
    [SerializeField] GameObject Presi;

    [Header("Scripts")]
    DestruirPresi destruirPresi;
    DialogosNPCs dialogosNPCs;
    ControladorSFX controladorSFX;
    Jugador jugador;
    SombrasCajon sombrasCajon;
    DestruirPaul destruirPaul;
    Boton boton;
    Puzzles puzzles;
    DetectorSonidoF detectorSonidoF;
    PasaDia pasaDia;

    [Header("Variables")]
    public bool sePuedeDormir = false;
    public bool pasapasa;

    void Start()
    {
        dialogosNPCs = FindObjectOfType<DialogosNPCs>();
        controladorSFX = FindObjectOfType<ControladorSFX>();
        destruirPresi = FindObjectOfType<DestruirPresi>();
        jugador = FindObjectOfType<Jugador>();
        sombrasCajon = FindObjectOfType<SombrasCajon>();
        destruirPaul = FindObjectOfType<DestruirPaul>();
        boton = FindObjectOfType<Boton>();
        puzzles = FindObjectOfType<Puzzles>();
        pasaDia = FindObjectOfType<PasaDia>();
        detectorSonidoF = FindObjectOfType<DetectorSonidoF>();

        cama.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        PrimeraEscenaPresi();
        TutorialObjetos();
        EscenaItziar();
        EscenaMarioSonambulo();
        Dormir1();
        PuzlePaul();
        EscenaExtintoresYPresi();
        GrabarConjavi();
        Juicio();
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
            destruirPresi.destPresi = false;
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

            puertaPasillo101.SetActive(false);
            puertaPasillo102.SetActive(false);
        }
    }

    void EscenaItziar()
    {
        if (sombrasCajon.objOrganizados >= 7)
        {
            StartCoroutine(Esperar1());
            cajon.tag = "nada";
            humo.GetComponent<Animator>().SetBool("Ahumar", true);
            itziarCubo.transform.position = new Vector3(-323.8378f, 8.95f, -38.61416f);
        }
        if (dialogosNPCs.contadorItziar == 7)
        {
            humo.GetComponent<Animator>().SetBool("Ahumar", false);
            itziarCubo.transform.position = new Vector3(0f, 0f, 200f);
            caja.SetActive(false);
            humo.SetActive(false);
        }
    }

    void EscenaMarioSonambulo()
    {
        if (dialogosNPCs.habladoConPersonajes == 7)
        {
            //Setup
            mision3.GetComponent<Animator>().SetBool("HaPasado", true);
            controladorSFX.ArrastrarSilla();
            StartCoroutine(Esperar());
            Mario.transform.position = new Vector3(-320.545f, 8.068f, -33.398f);
            Mario.transform.rotation = Quaternion.Euler(0, -83.595f, 0);
            Javier.transform.position = new Vector3(-319.55f, 8.084f, -32.6f);
            Javier.transform.rotation = Quaternion.Euler(0, 166.89f, 0);
            Javier.tag = "Activable";
            dialogosNPCs.PuedeHablarJavier = true;
            dialogosNPCs.habladoConPersonajes++;
        }

        //Inicio del dialogo
        if (dialogosNPCs.contadorJavier == 11)
        {
            Mario.tag = "Activable";
            dialogosNPCs.PuedeHablarMario = true;
            dialogosNPCs.contadorJavier++;
        }
        if (dialogosNPCs.contadorMario == 9)
        {
            Javier.tag = "Activable";
            dialogosNPCs.PuedeHablarJavier = true;
            dialogosNPCs.contadorMario++;
        }
        if (dialogosNPCs.contadorJavier == 15)
        {
            Mario.tag = "Activable";
            dialogosNPCs.PuedeHablarMario = true;
            dialogosNPCs.contadorJavier++;
        }
        if (dialogosNPCs.contadorMario == 12)
        {
            sePuedeDormir = true;
            dialogosNPCs.contadorMario++;
        }
        //Fin del dialogo
    }

    void Dormir1()
    {
        if (sePuedeDormir == true)
        {
            cama.SetActive(true);
            Debug.Log("Poner Tags");
            sePuedeDormir = false;
        }

        if (Input.GetKeyDown(KeyCode.E) && jugador.rayoAccionToca == true)
        {
            if (jugador.nombreObjActivable == "cama")
            {
                pasapasa = true;
                //SetUp Dia 2
                notaItziar.SetActive(true);
                Javier.transform.position = new Vector3(-318.687f, 8.084f, -34.49f);
                Javier.transform.rotation = Quaternion.Euler(0, 259.704f, 0);
                Isma.transform.position = new Vector3(-319.543f, 8.069f, -33.767f);
                Isma.transform.rotation = Quaternion.Euler(0, 166.19f, 0);
                Mario.transform.position = new Vector3(-316.87f, 8.068f, -18.141f);
                Mario.transform.rotation = Quaternion.Euler(0, 66.079f, 0);
                Nestor.transform.position = new Vector3(-320.022f, 20.334f, -32.971f);
                Nestor.transform.rotation = Quaternion.Euler(0, 237.644f, 0);
                Presi.transform.position = new Vector3(-321.06f, 20.256f, -47.629f);
                Presi.transform.rotation = Quaternion.Euler(0, -325.387f, 0);
                Paul.transform.position = new Vector3(-318.536f, 8.055f, -27.805f);
                Paul.transform.rotation = Quaternion.Euler(0, -128.889f, 0);

                DestructorPaul.SetActive(true);

                ordenadorPaul.tag = "Puzzle";
                Debug.Log("Tag dado");

                Javier.tag = "Activable";
                dialogosNPCs.PuedeHablarJavier = true;
                Debug.Log("Javier Habla");

                Paul.tag = "Activable";
                dialogosNPCs.PuedeHablarPaul = true;

                new WaitForEndOfFrame();
                cama.SetActive(false);
            }
        }

        //Inicio Dialogo
        if (dialogosNPCs.contadorJavier == 19)
        {
            dialogosNPCs.contadorJavier++;
            Isma.tag = "Activable";
            dialogosNPCs.PuedeHablarIsrael = true;
        }

        if (dialogosNPCs.contadorIsrael == 8)
        {
            dialogosNPCs.contadorIsrael++;
        }
        //Fin Dialogo
        if (dialogosNPCs.contadorPaul == 12)
        {
            dialogosNPCs.contadorPaul++;
            mision4.GetComponent<Animator>().SetBool("HaPasado", true);
            StartCoroutine(Esperar());
        }
    }

    void PuzlePaul()
    {
        if (boton.confirmacion == true)
        {
            StartCoroutine(Copiar());
            Paul.transform.position = new Vector3(Layla.transform.position.x, Layla.transform.position.y - 0.8f, Layla.transform.position.z + 1f);
            Paul.transform.rotation = Quaternion.Euler(0, Layla.transform.rotation.y + 180, 0);
            dialogosNPCs.PuedeHablarPaul = true;
            Paul.tag = "Activable";
            boton.confirmacion = false;
        }

        if (dialogosNPCs.contadorPaul == 16)
        {
            Presi.transform.position = new Vector3(-317.991f, 7.969f, -25.961f);
            Presi.transform.rotation = Quaternion.Euler(0, -252.242f, 0);
            dialogosNPCs.contadorPaul++;
            ordenadorPaul.tag = "nada";
        }
    }

    void EscenaExtintoresYPresi()
    {
        if (dialogosNPCs.contadorPaul == 17)
        {
            extintorNormal.SetActive(false);
            sistemaParticulas.SetActive(true);
            extintorRoto.SetActive(true);
            dialogosNPCs.PuedeHablarPresi = true;
            Presi.tag = "Activable";
            dialogosNPCs.contadorPaul++;
        }
        if (dialogosNPCs.contadorPresi == 14)
        {
            dialogosNPCs.contadorPresi++;
        }
        if (jugador.ObjMano == mazo)
        {
            dialogosNPCs.PuedeHablarPresi = true;
            Presi.tag = "Activable";
            Destroy(jugador.ObjMano);
            jugador.ObjMano = null;
            jugador.manoLlena = false;
        }
        if (dialogosNPCs.contadorPresi == 19)
        {
            Debug.Log("No estoy");
            Javier.transform.position = new Vector3(-319.076f, 8.084f, -31.89f);
            Javier.transform.rotation = Quaternion.Euler(0, -25.258f, 0);
            Isma.transform.position = new Vector3(-307.0163f, 20.39014f, -23.22144f);
            Isma.transform.rotation = Quaternion.Euler(0, 149.697f, 0);
            Javier.tag = "Activable";
            dialogosNPCs.PuedeHablarJavier = true;
            movil.SetActive(true);
            sistemaParticulas.SetActive(false);
            dialogosNPCs.contadorPresi++;
        }
    }

    void GrabarConjavi()
    {
        if (jugador.ObjMano == movil)
        {
            Javier.transform.position = new Vector3(-312.981f, 20.36f, -37.914f);
            Javier.transform.rotation = Quaternion.Euler(0, 121.297f, 0);
            dialogosNPCs.PuedeHablarJavier = true;
            Javier.tag = "Activable";
            StartCoroutine(SonidoF());
            Destroy(jugador.ObjMano);
            jugador.ObjMano = null;
            jugador.manoLlena = false;
        }
        if (dialogosNPCs.contadorJavier == 30)
        {
            Presi.transform.position = new Vector3(-320.919f, 20.275f, -43.482f);
            Presi.transform.rotation = Quaternion.Euler(0, -248.019f, 0);
            Presi.tag = "Activable";
            dialogosNPCs.PuedeHablarPresi = true;
            mision5.GetComponent<Animator>().SetBool("HaPasado", true);
            StartCoroutine(Esperar());
            dialogosNPCs.contadorJavier++;
        }
        if (dialogosNPCs.contadorPresi == 31)
        {
            mision3.GetComponent<Animator>().SetBool("HaPasado", true);
            StartCoroutine(Esperar());
            Javier.transform.position = new Vector3(0, 0, 200);
            cama.SetActive(true);
            dialogosNPCs.contadorPresi++;
        }
    }

    void Juicio()
    {
        if (pasaDia.VpasaDia == 2)
        {
            mision6.GetComponent<Animator>().SetBool("HaPasado", true);
            StartCoroutine(Esperar());
            LanzadorEscena.SetActive(true);
        }
    }

    IEnumerator SonidoF()
    {
        yield return new WaitForSeconds(6f);
        Debug.Log("Sonido fuerte");
    }

    IEnumerator Esperar()
    {
        yield return new WaitForSeconds(4f);
        //Cuadros de mision
        mision1.GetComponent<Animator>().SetBool("HaPasado", false);
        mision2.GetComponent<Animator>().SetBool("HaPasado", false);
        mision3.GetComponent<Animator>().SetBool("HaPasado", false);
        mision4.GetComponent<Animator>().SetBool("HaPasado", false);
        mision5.GetComponent<Animator>().SetBool("HaPasado", false);
    }

    IEnumerator Esperar1()
    {
        yield return new WaitForSeconds(2f);
        //Cajon cerrar
        controladorSFX.CerrarCajon();
        cajon.GetComponent<Animator>().SetBool("Abrir", false);
        //PasarDia.GetComponent<Animator>().SetBool("PasarDia", false);
    }

    IEnumerator Copiar()
    {
        fondoCopiar.SetActive(true);
        yield return new WaitForSeconds(3f);
        //Sonido informatico
        puzlePaul.SetActive(false);
    }
}   