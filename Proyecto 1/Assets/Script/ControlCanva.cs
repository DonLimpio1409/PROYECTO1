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
    [SerializeField] Animator animJugador; 

    [Header("Variables")]
    public bool estaJugando;
    float contador;

    [Header("Scripts")]
    Jugador ScrJugador;

    void Start()
    {
        ScrJugador = FindObjectOfType<Jugador>();

        //Asegurrarse de que el raton es libre
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    void Update()
    {
        contador += Time.deltaTime; 
    }

    public void Jugar()
    {
        //Que empiece la animacion del principio del juego
        StartCoroutine(EjecutarDespuesDeAnimacion());

        ScrJugador.CentrarRaton();
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
