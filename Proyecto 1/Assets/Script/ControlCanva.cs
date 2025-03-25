using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
public class ControlCanva : MonoBehaviour
{
    [Header("Jugador")]
    [SerializeField] GameObject MenuPrincipal;
    [SerializeField] GameObject MenuDeOpciones;
    [SerializeField] GameObject Interfaz;
    [SerializeField] Scrollbar ScrolSensivilidad;

    [Header("Variables")]
    public bool estaJugando;

    [Header("Scripts")]
    Jugador ScrJugador;

    void Start()
    {
        ScrJugador = FindObjectOfType<Jugador>();

        //Asegurrarse de que el raton es libre
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    public void Jugar()
    {
        //Que empiece la animacion del principio del juego

        estaJugando = true;

        MenuPrincipal.SetActive(false);
        Interfaz.SetActive(true);
    }

    public void Opciones()
    {
        MenuPrincipal.SetActive(false);
        MenuDeOpciones.SetActive(true);

        //Control sensivilidad
        ScrJugador.sensibilidadHorizontal = ScrolSensivilidad.value * 1000; 
        ScrJugador.sensibilidadVertical = ScrolSensivilidad.value * 1000;

        if(ScrolSensivilidad.value == 0)
        {
            ScrolSensivilidad.value = 0.1f;
            ScrJugador.sensibilidadHorizontal = ScrolSensivilidad.value * 1000; 
            ScrJugador.sensibilidadVertical = ScrolSensivilidad.value * 1000;
        }
    }

    public void Salir()
    {
        #if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false; // Detiene el juego en el editor
        #else
            Application.Quit(); // Cierra la aplicación en una build
        #endif
    }
}
