using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DialogosNPCs : MonoBehaviour
{
    [Header("Sprites paneles")]
    [SerializeField] Sprite CuadroPresidenta;

    [Header("Scripts")]
    Jugador ScrJugador;
    ObtDialogos ScrDialogos;
    ControlCanva ScrControlCanva;
    TpObjNpc ScrtpObjNpc;

    [Header("Obgetos")]
    [SerializeField] TextMeshProUGUI textoDialogo;
    [SerializeField] GameObject CuadroDialogo;

    [Header("Variables")]
    string textoAEnseñar;
    [SerializeField] float tiempoTipeado = 0.5f;
    bool mostrandoTexto;

    // Cooldowns individuales para cada personaje
    Dictionary<string, float> cooldownsNPC = new Dictionary<string, float>();
    [SerializeField] float tiempoCooldown = 120f;

    //Contadores
    public int contadorPresi = 1;


    // Start is called before the first frame update
    void Start()
    {
        ScrJugador = FindObjectOfType<Jugador>();
        ScrDialogos = FindObjectOfType<ObtDialogos>();
        ScrControlCanva = FindObjectOfType<ControlCanva>();
    }

    // Update is called once per frame
    void Update()
    {
        Hablar();
    }

   void Hablar()
    {
        if (ScrControlCanva.estaJugando == true)
        {
            if (Input.GetKeyDown(KeyCode.E) && ScrJugador.rayoAccionToca == true)
            {
                string nombreNPC = ScrJugador.nombreObjActivable;

                // Comprobar si el NPC está en cooldown
                if (cooldownsNPC.ContainsKey(nombreNPC) && Time.time < cooldownsNPC[nombreNPC])
                {
                    Debug.Log($"{nombreNPC} todavía está en cooldown.");
                    return;
                }

                CuadroDialogo.SetActive(true);

                // Si está escribiéndose el texto, interrumpimos y lo mostramos completo
                if (mostrandoTexto == true)
                {
                    StopAllCoroutines();
                    textoDialogo.text = textoAEnseñar;
                    mostrandoTexto = false;
                    return;
                }

                // Si no se está escribiendo nada, empieza el nuevo diálogo
                switch (ScrJugador.nombreObjActivable)
                {
                    case "Presidenta":
                        contadorPresi++;
                        textoAEnseñar = ScrDialogos.ObtenerDialogo(1, contadorPresi);
                        textoDialogo.text = "";
                        CuadroDialogo.GetComponent<Image>().sprite = CuadroPresidenta;
                        CuadroDialogo.SetActive(true);

                        StartCoroutine(EnseñarTexto(nombreNPC));

                        break;
                }

                if(ScrJugador.rayoAccionToca == false)
                {
                    CuadroDialogo.SetActive(false);
                }
            }
        }
    }
    IEnumerator EnseñarTexto(string nombreNPC)
    {
        mostrandoTexto = true;
        foreach (char caracter in textoAEnseñar)
        {
            if (caracter == '#')
            {
                CuadroDialogo.SetActive(false);

                // Ahora sí, cuando aparece #, empezamos el cooldown para ese NPC
                cooldownsNPC[nombreNPC] = Time.time + tiempoCooldown;

                break;
            }
            else
            {
                textoDialogo.text += caracter;
                yield return new WaitForSeconds(tiempoTipeado);
            }
        }
        mostrandoTexto = false;
    }
}

