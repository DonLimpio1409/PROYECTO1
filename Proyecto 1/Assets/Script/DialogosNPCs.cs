using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DialogosNPCs : MonoBehaviour
{
    [Header("Sprites paneles")]
    [SerializeField] Sprite CuadroPresidenta;
    [SerializeField] Sprite CuadroIsrrael;
    [SerializeField] Sprite CuadroNestor;
    [SerializeField] Sprite CuadroMario;
    [SerializeField] Sprite CuadroJavier;
    [SerializeField] Sprite CuadroPaul;
    [SerializeField] Sprite CuadroPensamientoLayla;

    [Header("Contadores dialogos")]
    public int contadorPresi = 1;
    public int contadorIsrael = 1;
    public int contadorNestor = 1;
    public int contadorMario = 1;
    public int contadorJavier = 1;
    public int contadorPaul = 1;
    public int contadorPensarLayla = 1; 

    [Header("Boolleanos dialogos")]
    public bool PuedeHablarPresi = true;
    public bool PuedeHablarIsrael = true;
    public bool PuedeHablarNestor = true;
    public bool PuedeHablarMario = true;
    public bool PuedeHablarJavier = true;
    public bool PuedeHablarPaul = true;
    public bool PuedePensarLayla = false;

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
        PiensaLayla();
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
                        if(PuedeHablarPresi == true)
                        {
                            contadorPresi++;
                            textoAEnseñar = ScrDialogos.ObtenerDialogo(1, contadorPresi);
                            textoDialogo.text = "";
                            CuadroDialogo.GetComponent<Image>().sprite = CuadroPresidenta;
                            CuadroDialogo.SetActive(true);

                            StartCoroutine(EnseñarTexto());
                            
                            break;
                        }
                        break;

                    case "Israel":
                        if(PuedeHablarIsrael == true)
                        {
                            contadorIsrael++;
                            textoAEnseñar = ScrDialogos.ObtenerDialogo(5, contadorIsrael);
                            textoDialogo.text = "";
                            CuadroDialogo.GetComponent<Image>().sprite = CuadroIsrrael;
                            CuadroDialogo.SetActive(true);

                            StartCoroutine(EnseñarTexto());

                            break;
                        }
                        break;

                    case "Nestor":
                        if(PuedeHablarNestor == true)
                        {
                            contadorNestor++;
                            textoAEnseñar = ScrDialogos.ObtenerDialogo(8, contadorNestor);
                            textoDialogo.text = "";
                            CuadroDialogo.GetComponent<Image>().sprite = CuadroNestor;
                            CuadroDialogo.SetActive(true);

                            StartCoroutine(EnseñarTexto());

                            break;  
                        }  
                        break;
                    case "Mario":
                        if(PuedeHablarMario == true)
                        {
                            contadorMario++;
                            textoAEnseñar = ScrDialogos.ObtenerDialogo(7, contadorMario);
                            textoDialogo.text = "";
                            CuadroDialogo.GetComponent<Image>().sprite = CuadroMario;
                            CuadroDialogo.SetActive(true);

                            StartCoroutine(EnseñarTexto());

                            break;
                        }
                        break;

                    case "Javier":
                        if(PuedeHablarJavier == true)
                        {
                            contadorJavier++;
                            textoAEnseñar = ScrDialogos.ObtenerDialogo(4, contadorJavier);
                            textoDialogo.text = "";
                            CuadroDialogo.GetComponent<Image>().sprite = CuadroJavier;
                            CuadroDialogo.SetActive(true);

                            StartCoroutine(EnseñarTexto());

                            break;
                        }
                        break;

                    case "Paul":
                        if(PuedeHablarPaul == true)
                        {
                            contadorJavier++;
                            textoAEnseñar = ScrDialogos.ObtenerDialogo(4, contadorJavier);
                            textoDialogo.text = "";
                            CuadroDialogo.GetComponent<Image>().sprite = CuadroJavier;
                            CuadroDialogo.SetActive(true);

                            StartCoroutine(EnseñarTexto());

                            break;
                        }
                        break;
                }

                if(ScrJugador.rayoAccionToca == false)
                {
                    CuadroDialogo.SetActive(false);
                }
            }
        }
    }

    void PiensaLayla()
    {
        if(PuedePensarLayla == true)
        {
            contadorPensarLayla++;
            textoAEnseñar = ScrDialogos.ObtenerDialogo(4, contadorPensarLayla);
            textoDialogo.text = "";
            CuadroDialogo.GetComponent<Image>().sprite = CuadroPensamientoLayla;
            CuadroDialogo.SetActive(true);

            StartCoroutine(EnseñarTexto());
        }
    }
    IEnumerator EnseñarTexto()
    {
        mostrandoTexto = true;
        foreach (char caracter in textoAEnseñar)
        {
            if (caracter == '#')
            {
                CuadroDialogo.SetActive(false);
                PuedeHablarPresi = false;

                break;
            }
            else if (caracter == '$')
            {
                CuadroDialogo.SetActive(false);
                PuedeHablarIsrael = false;

                break;
            }
            else if (caracter == 'º')
            {
                CuadroDialogo.SetActive(false);
                PuedeHablarNestor = false;

                break;
            }
            else if (caracter == '=')
            {
                CuadroDialogo.SetActive(false);
                PuedeHablarMario = false;

                break;
            }
            else if (caracter == '%')
            {
                CuadroDialogo.SetActive(false);
                PuedeHablarJavier = false;

                break;
            }
            else if (caracter == '/')
            {
                CuadroDialogo.SetActive(false);
                PuedeHablarPaul = false;

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

