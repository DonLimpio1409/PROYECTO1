using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Puzzles : MonoBehaviour
{
    [Header("Scripts")]
    Jugador ScrJugador;
    ControlCanva controlCanvas;

    [Header("Camaras")]
    public GameObject camaraPuzzle;
    private Camera camaraPrincipal;

    [Header("Posiciones Camara")]
    [SerializeField] Transform posicionCajon;

    [Header("")]
    public bool enPuzzle;

    void Start()
    {
        ScrJugador = FindObjectOfType<Jugador>();
        controlCanvas = FindObjectOfType<ControlCanva>();
        camaraPrincipal = Camera.main;
    }

    void Update()
    {
        PasarCamaraPuzzle();
    }

    void PasarCamaraPuzzle()
    {
        if (Input.GetKeyDown(KeyCode.E) && ScrJugador.rayoPuzzleToca)
        {
            controlCanvas.EntrarPuzle();
            switch (ScrJugador.nombrePuzzle)
            {
                case "Cajon":
                    camaraPuzzle.transform.position = posicionCajon.transform.position;
                    break;
            }

            enPuzzle = camaraPuzzle.activeSelf;
            camaraPuzzle.SetActive(!enPuzzle);
            enPuzzle = !enPuzzle;

            if (camaraPrincipal != null)
            {
                camaraPrincipal.gameObject.SetActive(!enPuzzle);
                controlCanvas.SalirPuzle();
            }

            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
    }

    
}
