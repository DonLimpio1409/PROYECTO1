using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControladorSFX : MonoBehaviour
{
    [Header("Audios Sources")]
    [SerializeField] AudioSource SFX;
    [SerializeField] AudioSource Musicas;

    [Header("Audios Clips")]
    //SFX
    [SerializeField] AudioClip sonidoPulsarBoton;
    [SerializeField] AudioClip pasos;
    [SerializeField] AudioClip puertas; 
    [SerializeField] AudioClip ruido1;
    [SerializeField] AudioClip plopBotones;
    [SerializeField] AudioClip abrrirPuerta;
    [SerializeField] AudioClip cerrarPuerta;
    [SerializeField] AudioClip puertaCerrada;

    //Musicas
    [SerializeField] AudioClip MusicaPasilloDia1;

    [Header("Variables")]
    float duracionFadeOut = 2.5f;
    int contador = 0;
    bool yaReproducido = false;
    bool SonandoAlgo = false;

    [Header("Script")]
    ControlCanva controlCanva;
    DialogosNPCs dialogosNPCs;
    Jugador jugador;

    [Header("Sistema para musicas")]
    [SerializeField] GameObject Jugador;
    GameObject trigerActual;

    void Start()
    {
        //Script
        controlCanva = FindObjectOfType<ControlCanva>();
        dialogosNPCs = FindObjectOfType<DialogosNPCs>();
        jugador = FindObjectOfType<Jugador>();
    }

    void Update()
    {
        //Deteccion de triger
        trigerActual = jugador.objetoContactado;

        //Control inicial
        if(controlCanva.estaJugando == true && contador == 0)
        {
            SFX.Stop();
            contador++;
        }

        if(controlCanva.abrirPuertas == true)
        {
            SFX.PlayOneShot(puertas);
            controlCanva.abrirPuertas = false;
        }

        //Musica general del juego
        ReproductorDeMusica();
    }

    public void PlopBotones()
    {
        SFX.PlayOneShot(plopBotones);   
    }
    public void PulsarBoton()
    {
        SFX.PlayOneShot(sonidoPulsarBoton); 
    }

    public void SonidoAbrePuerta()
    {
        SFX.PlayOneShot(abrrirPuerta);
    }

    public void SonidoCierraPuerta()
    {
        SFX.PlayOneShot(cerrarPuerta);
    }

    public void CallarPantallaTitulo()
    {
        StartCoroutine(FadeOut(Musicas, duracionFadeOut));

        if(controlCanva.estoyEnMenuPrincipal == false)
        {
            SFX.PlayOneShot(pasos);
        }
    }

    private IEnumerator FadeOut(AudioSource audioSource, float duracion)
    {
        float inicioVolumen = audioSource.volume;

        while (audioSource.volume > 0)
        {
            audioSource.volume -= inicioVolumen * Time.deltaTime / duracion;
            yield return null;
        }

        audioSource.Stop();
        audioSource.volume = inicioVolumen; // Por si quieres volver a usarlo
    }

    public void PrimerSonidoRuido()
    {
        if(dialogosNPCs.contadorPresi == 5 && yaReproducido == false)
        {
            StartCoroutine(Ruido1Tiempo());
        }
    }
    private IEnumerator Ruido1Tiempo()
    {    
        yaReproducido = true; 
        yield return new WaitForSeconds(0.5f);
        SFX.PlayOneShot(ruido1);
        
    }

    public void ReproductorDeMusica()
    {

        switch(trigerActual.name)
        {
            case "TrigerMusicaPasillo":
            if(SonandoAlgo == false)
            {
                Musicas.clip = MusicaPasilloDia1;
                Musicas.Play();
                SonandoAlgo = true;
            }
            break;
        }
    }
    public void PuertaCerrada()
    {
        SFX.PlayOneShot(puertaCerrada);
    }
}
