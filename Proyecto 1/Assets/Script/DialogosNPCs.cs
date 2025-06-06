using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Unity.VisualScripting;

public class DialogosNPCs : MonoBehaviour
{
    [Header("Sprites paneles")]
    [SerializeField] Sprite CuadroPresidenta;
    [SerializeField] Sprite CuadroIsrrael;
    [SerializeField] Sprite CuadroNestor;
    [SerializeField] Sprite CuadroMario;
    [SerializeField] Sprite CuadroJavier;
    [SerializeField] Sprite CuadroPaul;
    [SerializeField] Sprite CuadroItziar;

    [Header("Contadores dialogos")]
    public int contadorPresi = 1;
    public int contadorIsrael = 1;
    public int contadorNestor = 1;
    public int contadorMario = 1;
    public int contadorJavier = 1;
    public int contadorPaul = 1;
    public int contadorItziar = 1;

    [Header("Boolleanos dialogos")]
    public bool PuedeHablarPresi = true;
    public bool PuedeHablarIsrael = true;
    public bool PuedeHablarNestor = true;
    public bool PuedeHablarMario = true;
    public bool PuedeHablarJavier = true;
    public bool PuedeHablarPaul = true;
    public bool PuedeHablarItziar = true;

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
                        if (PuedeHablarPresi == true)
                        {
                            contadorPresi++;
                            textoAEnseñar = ScrDialogos.ObtenerDialogo(1, contadorPresi);
                            textoDialogo.text = "";
                            CuadroDialogo.GetComponent<Image>().sprite = CuadroPresidenta;
                            CuadroDialogo.SetActive(true);

                            if (textoAEnseñar == "#")
                            {
                                Debug.Log("Dentro");
                                PuedeHablarPresi = false;
                                CuadroDialogo.SetActive(false);
                                return;
                            }

                            StartCoroutine(EnseñarTexto());
                        }
                        break;

                    case "Israel":
                        if (PuedeHablarIsrael == true)
                        {
                            contadorIsrael++;
                            textoAEnseñar = ScrDialogos.ObtenerDialogo(5, contadorIsrael);
                            textoDialogo.text = "";
                            CuadroDialogo.GetComponent<Image>().sprite = CuadroIsrrael;
                            CuadroDialogo.SetActive(true);

                            if (textoAEnseñar.Contains('$'))
                            {
                                PuedeHablarPresi = false;
                                CuadroDialogo.SetActive(false);
                            }

                            StartCoroutine(EnseñarTexto());

                            break;
                        }
                        break;

                    case "Nestor":
                        if (PuedeHablarNestor == true)
                        {
                            contadorNestor++;
                            textoAEnseñar = ScrDialogos.ObtenerDialogo(8, contadorNestor);
                            textoDialogo.text = "";
                            CuadroDialogo.GetComponent<Image>().sprite = CuadroNestor;
                            CuadroDialogo.SetActive(true);

                            if (textoAEnseñar == "#")
                            {
                                Debug.Log("Dentro");
                                PuedeHablarPresi = false;
                                CuadroDialogo.SetActive(false);
                                return;
                            }

                            StartCoroutine(EnseñarTexto());

                            break;
                        }
                        break;

                    case "Mario":
                        if (PuedeHablarMario == true)
                        {
                            contadorMario++;
                            textoAEnseñar = ScrDialogos.ObtenerDialogo(7, contadorMario);
                            textoDialogo.text = "";
                            CuadroDialogo.GetComponent<Image>().sprite = CuadroMario;
                            CuadroDialogo.SetActive(true);

                            if (textoAEnseñar == "=")
                            {
                                Debug.Log("Dentro");
                                PuedeHablarPresi = false;
                                CuadroDialogo.SetActive(false);
                                return;
                            }

                            StartCoroutine(EnseñarTexto());

                            break;
                        }
                        break;

                    case "Javier":
                        if (PuedeHablarJavier == true)
                        {
                            contadorJavier++;
                            textoAEnseñar = ScrDialogos.ObtenerDialogo(4, contadorJavier);
                            textoDialogo.text = "";
                            CuadroDialogo.GetComponent<Image>().sprite = CuadroJavier;
                            CuadroDialogo.SetActive(true);

                            if (textoAEnseñar == "&")
                            {
                                Debug.Log("Dentro");
                                PuedeHablarPresi = false;
                                CuadroDialogo.SetActive(false);
                                return;
                            }

                            StartCoroutine(EnseñarTexto());

                            break;
                        }
                        break;
                    
                    case "Itziar":
                        if (PuedeHablarItziar == true)
                        {
                            contadorItziar++;
                            textoAEnseñar = ScrDialogos.ObtenerDialogo(2, contadorItziar);
                            textoDialogo.text = "";
                            CuadroDialogo.GetComponent<Image>().sprite = CuadroItziar;
                            CuadroDialogo.SetActive(true);

                            if (textoAEnseñar == "ç")
                            {
                                Debug.Log("Dentro");
                                PuedeHablarItziar = false;
                                CuadroDialogo.SetActive(false);
                                return;
                            }

                            StartCoroutine(EnseñarTexto());
                        }
                        break;

                    case "Paul":
                        if (PuedeHablarPaul == true)
                        {
                            contadorJavier++;
                            textoAEnseñar = ScrDialogos.ObtenerDialogo(4, contadorJavier);
                            textoDialogo.text = "";
                            CuadroDialogo.GetComponent<Image>().sprite = CuadroJavier;
                            CuadroDialogo.SetActive(true);

                            if (textoAEnseñar == "/")
                            {
                                Debug.Log("Dentro");
                                PuedeHablarPresi = false;
                                CuadroDialogo.SetActive(false);
                                return;
                            }

                            StartCoroutine(EnseñarTexto());

                            break;
                        }
                        break;
                }

                if (ScrJugador.rayoAccionToca == false)
                {
                    CuadroDialogo.SetActive(false);
                }
            }
        }
    }
    IEnumerator EnseñarTexto()
    {
        mostrandoTexto = true;
        textoDialogo.text = "";

        for (int i = 0; i < textoAEnseñar.Length; i++)
        {
            char caracter = textoAEnseñar[i];
            textoDialogo.text += caracter;
            yield return new WaitForSeconds(tiempoTipeado);
        }

        mostrandoTexto = false;
    }
}

