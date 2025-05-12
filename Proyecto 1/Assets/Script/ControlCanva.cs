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
    [SerializeField] GameObject MenuSubirBajar;

    [Header("Variables")]
    public bool estaJugando;
    float contador;
    bool estoyEnMenuPausa = false;
    public bool estoyEnMenuPrincipal = true;
    public bool abrirPuertas = false;
    bool estoyEnOtroMenu = true;

    [Header("Scripts")]
    Jugador ScrJugador;
    CambioDePlanta cambioDePlanta;

    [Header("Animators")]
    [SerializeField] Animator PuertaDer;
    [SerializeField] Animator PuertaId;
    [SerializeField] Animator AnimMovilPausa;

    void Start()
    {
        ScrJugador = FindObjectOfType<Jugador>();
        cambioDePlanta = FindObjectOfType<CambioDePlanta>();

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

        //Ajustar todos lo posible para jugar
        ScrJugador.CentrarRaton();
        MenuPrincipal.SetActive(false);
        Interfaz.SetActive(true);
        estoyEnMenuPrincipal = false;
    }

    public void Opciones()
    {
        MenuPrincipal.SetActive(false);
        MenuDePausa.SetActive(false);
        MenuDeOpciones.SetActive(true);
        estoyEnOtroMenu = true;
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
        if(Input.GetKey(KeyCode.Escape) && estoyEnOtroMenu == false)
        {
            estoyEnMenuPausa = true;
            MenuDePausa.SetActive(true);
            estaJugando = false;
            //Descentrar raton
            Cursor.lockState = CursorLockMode.None  ;
            Cursor.visible = true;  

            //Animacion
            AnimMovilPausa.SetBool("Pausado", true);
        }
    }

    public void Volver()
    {
        MenuDePausa.SetActive(false);
        ScrJugador.CentrarRaton();
        estaJugando = true;

        AnimMovilPausa.SetBool("Pausado", false);
    }

    public void Atras()
    {
        MenuDeOpciones.SetActive(false);
        estoyEnOtroMenu = false; 

        if(estoyEnMenuPrincipal == true)
        {
            MenuPrincipal.SetActive(true);
        }
        else 
        {
            MenuDePausa.SetActive(true);
            estoyEnMenuPausa = false;
        }
    }


    IEnumerator EjecutarDespuesDeAnimacion()
    {
        // Activar la animación
        animJugador.SetBool("EntrarHall", true);
        
        // Esperar a que entre en el estado deseado
        yield return new WaitUntil(() => animJugador.GetCurrentAnimatorStateInfo(0).IsName("AnimEntrarHall"));

        // Esperar un frame para asegurar que la animación ha arrancado completamente
        yield return null;

        // Obtener la duración de la animación actual
        float animDuracion = animJugador.GetCurrentAnimatorStateInfo(0).length;
        
        //Iniciar las animaciones de las puertas
        PuertaDer.SetBool("Abrir",true);
        PuertaId.SetBool("Abrir",true);
        abrirPuertas = true;
        
        // Esperar el tiempo de duración
        yield return new WaitForSeconds(animDuracion);

        // Desactivar animator si quieres congelar el personaje
        animJugador.enabled = false;

        // Continuar con el juego
        estaJugando = true;
        estoyEnOtroMenu = false; 
    }

    public void DesplegarSubirBajar()
    {
        MenuSubirBajar.SetActive(true);
        estoyEnOtroMenu = true;
        
        //Descentrar raton
        estaJugando = false;
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;  
    }

    public void SubirPlanta()
    {
        //Cambiar de planta
        cambioDePlanta.SubirPlanta();
        Debug.Log("Esto funciona");

        //Quitar Menu
        MenuSubirBajar.SetActive(false);
        estoyEnOtroMenu = false;

        //Centrar raton
        estaJugando = true;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false; 
    }

    public void BajarPlanta()
    {
        //Cambio de planta
        cambioDePlanta.BajarPlanta();

        //Quitar Menu
        MenuSubirBajar.SetActive(false);
        estoyEnOtroMenu = false;

        //Centrar raton
        estaJugando = true;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false; 
    }
}
