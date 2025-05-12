using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControladorSFX : MonoBehaviour
{
    [Header("Audios Sources")]
    [SerializeField] AudioSource SFX;
    [SerializeField] AudioSource PantallaDeTitulo;

    [Header("Audios Clips")]
    [SerializeField] AudioClip SonidoPulsarBoton;
    [SerializeField] AudioClip Pasos;
    [SerializeField] AudioClip Puertas; 
    [SerializeField] AudioClip Ruido1;
    [SerializeField] AudioClip plopBotones;

    [Header("Variables")]
    float duracionFadeOut = 2.5f;
    int contador = 0;
    bool yaReproducido = false;

    [Header("Script")]
    ControlCanva controlCanva;
    DialogosNPCs dialogosNPCs;

    void Start()
    {
        controlCanva = FindObjectOfType<ControlCanva>();
        dialogosNPCs = FindObjectOfType<DialogosNPCs>();
    }

    void Update()
    {
        //Control inicial
        if(controlCanva.estaJugando == true && contador == 0)
        {
            SFX.Stop();
            contador++;
        }

        if(controlCanva.abrirPuertas == true)
        {
            SFX.PlayOneShot(Puertas);
            controlCanva.abrirPuertas = false;
        }

        //Primer sonido de ruido
        PrimerSonidoRuido();
    }

    public void PlopBotones()
    {
        SFX.PlayOneShot(plopBotones);   
    }
    public void PulsarBoton()
    {
        SFX.PlayOneShot(SonidoPulsarBoton); 
    }

    public void CallarPantallaTitulo()
    {
        StartCoroutine(FadeOut(PantallaDeTitulo, duracionFadeOut));

        if(controlCanva.estoyEnMenuPrincipal == false)
        {
            SFX.PlayOneShot(Pasos);
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

    void PrimerSonidoRuido()
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
        SFX.PlayOneShot(Ruido1);
        
    }
}
