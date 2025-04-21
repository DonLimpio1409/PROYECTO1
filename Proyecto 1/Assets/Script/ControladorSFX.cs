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

    [Header("Variables")]
    float duracionFadeOut = 2;

    [Header("Script")]
    ControlCanva controlCanva;

    void Start()
    {
        controlCanva = FindObjectOfType<ControlCanva>();
    }

    void Update()
    {
        if(controlCanva.estaJugando == true)
        {
            SFX.Stop();
        }    
    }
    public void PulsarBoton()
    {
        SFX.PlayOneShot(SonidoPulsarBoton); 
    }

    public void CallarPantallaTitulo()
    {
        StartCoroutine(FadeOut(PantallaDeTitulo, duracionFadeOut));

        if(controlCanva.EstoyEnMenuPrincipal == false)
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
}
