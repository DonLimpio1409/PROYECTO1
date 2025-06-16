using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

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
    [SerializeField] Transform posicionOrdenadorPaul;

    [Header("")]
    public bool enPuzzle;

    [Header("PuzzlePaul")]
    [SerializeField] GameObject PuzzlePaul;
    public bool enPaul = false;


    void Start()
    {
        ScrJugador = FindObjectOfType<Jugador>();
        controlCanvas = FindObjectOfType<ControlCanva>();
        camaraPrincipal = Camera.main;
    }

    void Update()
    {
        PasarCamaraPuzzle();
        if (enPuzzle == true && enPaul == true)
        {
            PuzzlePaul.SetActive(true);
            enPaul = false;
        }
        else if (enPuzzle == false)
        {
            PuzzlePaul.SetActive(false);
        }

    }

    void PasarCamaraPuzzle()
    {
        if (Input.GetKeyDown(KeyCode.E) && ScrJugador.rayoPuzzleToca)
        {
            switch (ScrJugador.nombrePuzzle)
            {
                case "Cajon":
                    camaraPuzzle.transform.position = posicionCajon.transform.position;
                    camaraPuzzle.transform.rotation = posicionCajon.transform.rotation;
                    break;
                case "Monitor":
                    camaraPuzzle.transform.position = posicionOrdenadorPaul.transform.position;
                    camaraPuzzle.transform.rotation = posicionOrdenadorPaul.transform.rotation;
                    enPaul = true;
                    break;
            }

            enPuzzle = camaraPuzzle.activeSelf;
            camaraPuzzle.SetActive(!enPuzzle);
            enPuzzle = !enPuzzle;

            if (camaraPrincipal != null)
            {
                camaraPrincipal.gameObject.SetActive(!enPuzzle);
            }

            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
    }
}
