using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class Menu : MonoBehaviour
{
    [Header("Objetos")]
    [SerializeField] MovJugdor Jugador;
    [SerializeField] Animator animMenu;
    [SerializeField] Scrollbar Barra;

    public bool mirandoMenu = false;
    // Start is called before the first frame update
    void Start()
    {
        Barra.value = 0.5f;
        ModificarSensibilidad();
    }

    // Update is called once per frame
    void Update()
    {
        DesplegarMenu();
    }

    void DesplegarMenu()
    {  
        if(Input.GetKeyDown(KeyCode.Q))
        {
            Barra.enabled = true;; 
            animMenu.SetBool("MirandoMenu", true);
            mirandoMenu = true;
        }
    }

    public void ModificarSensibilidad()
    {
        Jugador.sensibilidadHorizontal = Barra.value * 1000; 
        Jugador.sensibilidadVertical = Barra.value * 1000;

        if(Barra.value == 0)
        {
            Barra.value = 0.1f;
            Jugador.sensibilidadHorizontal = Barra.value * 1000; 
            Jugador.sensibilidadVertical = Barra.value * 1000;
        }
    }

}
