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

    [Header("Obgetos")]
    [SerializeField] TextMeshProUGUI textoDialogo;
    [SerializeField] GameObject CuadroDialogo;

    [Header("Variables")]
    string textoAEnseñar;
    [SerializeField] float tiempoTipeado = 0.5f;
    bool mostrandoTexto;

    //Contadores
    int contadorPresi = 1;


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

                    StartCoroutine(EnseñarTexto());
                    break;
            }
        }
        else if (ScrJugador.rayoAccionToca == false)
        {
            CuadroDialogo.SetActive(false);
        }
    }
}
    IEnumerator EnseñarTexto()
    {
        mostrandoTexto = true;
        foreach(char caracter in textoAEnseñar)
        {
            textoDialogo.text += caracter;
            yield return new WaitForSeconds(tiempoTipeado);
        }
        mostrandoTexto = false;
    }
}
