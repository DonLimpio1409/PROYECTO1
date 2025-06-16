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
    [SerializeField] AudioClip abrirCajon;
    [SerializeField] AudioClip cerrarCajon;
    [SerializeField] AudioClip arrastrarSilla;

    [Header("Musicas")]
    [SerializeField] AudioClip MusicaPasilloDia1;
    [SerializeField] AudioClip MusicaCuartoPrin;
    [SerializeField] AudioClip MusicaCuartoJuanjo;
    [SerializeField] AudioClip MusicaCuartoIsma;
    [SerializeField] AudioClip MusicaCuartoNestor;
    [SerializeField] AudioClip MusicaCuartoPresi;
    [SerializeField] AudioClip MusicaCuartoPaul;
    [SerializeField] AudioClip MusicaTension;

    [Header("Variables")]
    float duracionFadeOut = 2.5f;
    int contador = 0;
    bool yaReproducido = false;

    //Boolleanos Musica
    [SerializeField] bool musicaPasilloDia1 = false;
    [SerializeField] bool musicaCuartoPrin = false;
    [SerializeField] bool musicaCuartoJuanjo = false;
    [SerializeField] bool musicaCuartoIsma = false;
    [SerializeField] bool musicaCuartoNestor = false;
    [SerializeField] bool musicaCuartoPresi = false;
    [SerializeField] bool musicaCuartoPaul = false;
    [SerializeField] bool musicaTension = false;

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

    bool Arrastrar = false;
    public void ArrastrarSilla()
    {
        if (Arrastrar == false)
        {
            SFX.PlayOneShot(arrastrarSilla);
            Arrastrar = true;   
        }
    }

    public void CallarPantallaTitulo()
    {
        StartCoroutine(FadeOut(Musicas, duracionFadeOut));

        if (controlCanva.estoyEnMenuPrincipal == false)
        {
            SFX.PlayOneShot(pasos);
        }
    }

    bool Abrir = false;
    public void AbrirCajon()
    {
        if (Abrir == false)
        {
            SFX.PlayOneShot(abrirCajon);
            Abrir = true;
        }
    }

    bool Cerrar = false;
    public void CerrarCajon()
    {
        if (Cerrar == false)
        {
            SFX.PlayOneShot(cerrarCajon);
            Cerrar = true;   
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
        if(yaReproducido == false)
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
        switch (trigerActual.name)
        {
            case "TrigerMusicaPasillo":
                if (musicaPasilloDia1 == false)
                {
                    //Silenciar al resto
                    musicaCuartoJuanjo = false;
                    musicaCuartoPrin = false;
                    musicaCuartoIsma = false;
                    musicaCuartoNestor = false;
                    musicaCuartoPresi = false;
                    musicaCuartoPaul = false;
                    musicaTension = false;

                    //Accion
                    Musicas.clip = MusicaPasilloDia1;
                    Musicas.Play();
                    musicaPasilloDia1 = true;
                }
                break;
            case "TrigerMusicaCuartoPrin":
                if (musicaCuartoPrin == false)
                {
                    //Silenciar al resto
                    musicaCuartoJuanjo = false;
                    musicaPasilloDia1 = false;
                    musicaCuartoIsma = false;
                    musicaCuartoNestor = false;
                    musicaCuartoPresi = false;
                    musicaCuartoPaul = false;
                    musicaTension = false;

                    //Accion
                    Musicas.clip = MusicaCuartoPrin;
                    Musicas.Play();
                    musicaCuartoPrin = true;
                }
                break;
            case "TrigerMusicaCuartoJuanjo":
                if (musicaCuartoJuanjo == false)
                {
                    //Silenciar al resto
                    musicaCuartoPrin = false;
                    musicaPasilloDia1 = false;
                    musicaCuartoIsma = false;
                    musicaCuartoNestor = false;
                    musicaCuartoPresi = false;
                    musicaCuartoPaul = false;
                    musicaTension = false;

                    //Accion
                    Musicas.clip = MusicaCuartoJuanjo;
                    Musicas.Play();
                    musicaCuartoJuanjo = true;
                }
                break;
            case "TrigerMusicaCuartoIsma":
                if (musicaCuartoIsma == false)
                {
                    //Silenciar al resto
                    musicaCuartoPrin = false;
                    musicaPasilloDia1 = false;
                    musicaCuartoJuanjo = false;
                    musicaCuartoNestor = false;
                    musicaCuartoPresi = false;
                    musicaCuartoPaul = false;
                    musicaTension = false;

                    //Accion
                    Musicas.clip = MusicaCuartoIsma;
                    Musicas.Play();
                    musicaCuartoIsma = true;
                }
                break;
            case "TrigerMusicaCuartoNestor":
                if (musicaCuartoNestor == false)
                {
                    //Silenciar al resto
                    musicaCuartoPrin = false;
                    musicaPasilloDia1 = false;
                    musicaCuartoJuanjo = false;
                    musicaCuartoIsma = false;
                    musicaCuartoPresi = false;
                    musicaCuartoPaul = false;
                    musicaTension = false;

                    //Accion
                    Musicas.clip = MusicaCuartoNestor;
                    Musicas.Play();
                    musicaCuartoNestor = true;
                }
                break;
            case "TrigerMusicaCuartoPresi":
                if (musicaCuartoPresi == false)
                {
                    //Silenciar al resto
                    musicaCuartoPrin = false;
                    musicaPasilloDia1 = false;
                    musicaCuartoJuanjo = false;
                    musicaCuartoIsma = false;
                    musicaCuartoNestor = false;
                    musicaCuartoPaul = false;
                    musicaTension = false;

                    //Accion
                    Musicas.clip = MusicaCuartoPresi;
                    Musicas.Play();
                    musicaCuartoPresi = true;
                }
                break;
            case "TrigerMusicaCuartoPaul":
                if (musicaCuartoPaul == false)
                {
                    //Silenciar al resto
                    musicaCuartoPrin = false;
                    musicaPasilloDia1 = false;
                    musicaCuartoJuanjo = false;
                    musicaCuartoIsma = false;
                    musicaCuartoNestor = false;
                    musicaCuartoPresi = false;
                    musicaTension = false;

                    //Accion
                    Musicas.clip = MusicaCuartoPaul;
                    Musicas.Play();
                    musicaCuartoPaul = true;
                }
                break;
                case "TriguerMusicaTension":
                if(musicaCuartoPaul == false)
                {
                    //Silenciar al resto
                    musicaCuartoPrin = false;
                    musicaPasilloDia1 = false;
                    musicaCuartoJuanjo = false;
                    musicaCuartoIsma = false;
                    musicaCuartoNestor = false;
                    musicaCuartoPresi = false;
                    musicaCuartoPaul = false;

                    //Accion
                    Musicas.clip = MusicaTension;
                    Musicas.Play();
                    musicaTension = true;
                }
                break;
        }
    }
    public void PuertaCerrada()
    {
        SFX.PlayOneShot(puertaCerrada);
    }
}
