using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DialogosNPCs : MonoBehaviour
{
    [Header("Scripts")]
    Jugador ScrJugador;
    ObtDialogos ScrDialogos;

    [Header("Obgetos")]
    [SerializeField] TextMeshProUGUI textoDialogo;
    [SerializeField] GameObject ParaContinuar;

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
    }

    // Update is called once per frame
    void Update()
    {
        Hablar();
    }

    void Hablar()
    {
        if(Input.GetKeyDown(KeyCode.E) && ScrJugador.rayoAccionToca == true)
        {
            ParaContinuar.SetActive(false);
            textoAEnseñar = "";

            if (mostrandoTexto == false)
            {
                switch(ScrJugador.nombreObjActivable)
                {
                    case "Presidenta":
                        //Setup
                        contadorPresi++;
                        textoDialogo.text = "";
                        //Reproduccion del texto
                        textoAEnseñar = ScrDialogos.ObtenerDialogo(1, contadorPresi);
                        StopAllCoroutines();
                        StartCoroutine(EnseñarTexto());
                        //Interfaz
                        ParaContinuar.SetActive(true);
                        break;
                }

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
