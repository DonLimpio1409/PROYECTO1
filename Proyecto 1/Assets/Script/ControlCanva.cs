using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
public class ControlCanva : MonoBehaviour
{
    [Header("Acciones de Menu")]
    [SerializeField] GameObject MenuPrincipal;
    [SerializeField] GameObject MenuDeOpciones;
    [SerializeField] GameObject Interfaz;
    [SerializeField] Scrollbar ScrolSensivilidad;
    [SerializeField] Scrollbar ScrolVolumen;
    [SerializeField] Animator animJugador; 
    [SerializeField] GameObject MenuDePausa;

    [Header("Variables")]
    public bool estaJugando;
    float contador;
    bool EstoyEnMenuPausa = false;
    bool EstoyEnMenuPrincipal = true;
    bool EstoyEnMenuDeOpciones;

    [Header("Scripts")]
    Jugador ScrJugador;

    void Start()
    {
        ScrJugador = FindObjectOfType<Jugador>();

        //Asegurrarse de que el raton es libre
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;

        // Sincronizar volumen inicial
        if (ScrolVolumen.value <= 0.01f)
        {
            ScrolVolumen.value = 0.05f;
        }

        AudioListener.volume = ScrolVolumen.value;
    }

    void Update()
    {
        Pausar();

        contador += Time.deltaTime; 
    }

    public void Jugar()
    {
        //Que empiece la animacion del principio del juego
        StartCoroutine(EjecutarDespuesDeAnimacion());

        ScrJugador.CentrarRaton();
        MenuPrincipal.SetActive(false);
        Interfaz.SetActive(true);
        EstoyEnMenuPrincipal = false;
    }

    public void Opciones()
    {
        MenuPrincipal.SetActive(false);
        MenuDePausa.SetActive(false);
        MenuDeOpciones.SetActive(true);
        EstoyEnMenuDeOpciones = true;
    }

    public void ControlSensibilidad()
    {
        ScrJugador.sensibilidadHorizontal = ScrolSensivilidad.value * 1000; 
        ScrJugador.sensibilidadVertical = ScrolSensivilidad.value * 1000;

        if(ScrolSensivilidad.value == 0)
        {
            ScrolSensivilidad.value = 0.0005f;
            ScrJugador.sensibilidadHorizontal = ScrolSensivilidad.value * 1000; 
            ScrJugador.sensibilidadVertical = ScrolSensivilidad.value * 1000;
        }
    }

    public void ControlVolumen()
    {
        AudioListener.volume = ScrolVolumen.value;
    }

    public void Salir()
    {
        #if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false; // Detiene el juego en el editor
        #else
            Application.Quit(); // Cierra la aplicación en una build
        #endif
    }

    //Menu de pausa
    void Pausar()
    {
        if(Input.GetKey(KeyCode.P) && EstoyEnMenuDeOpciones == false)
        {
            EstoyEnMenuPausa = true;
            MenuDePausa.SetActive(true);
            estaJugando = false;
            //Descentrar raton
            Cursor.lockState = CursorLockMode.None  ;
            Cursor.visible = true;  
        }
    }

    public void Volver()
    {
        MenuDePausa.SetActive(false);
        ScrJugador.CentrarRaton();
        estaJugando = true;
    }

    public void Atras()
    {
        MenuDeOpciones.SetActive(false);
        EstoyEnMenuDeOpciones = false; 

        if(EstoyEnMenuPrincipal == true)
        {
            MenuPrincipal.SetActive(true);
        }
        else 
        {
            MenuDePausa.SetActive(true);
            EstoyEnMenuPausa = false;
        }
    }


    IEnumerator EjecutarDespuesDeAnimacion()
    {
        // Iniciar la animación
        animJugador.SetBool("EntrarHall", true);

        // Esperar a que el estado de la animación sea el correcto
        yield return new WaitUntil(() => animJugador.GetCurrentAnimatorStateInfo(0).IsName("AnimEntrarHall"));

        // Obtener la duración de la animación
        float animDuracion = animJugador.GetCurrentAnimatorStateInfo(0).length;

        // Esperar a que termine la animación
        yield return new WaitForSeconds(animDuracion);

        animJugador.enabled = false; 
        
        // Ahora ejecutar el código después de la animación
        estaJugando = true;
    }
}
