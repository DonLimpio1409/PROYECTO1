using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Puzzles : MonoBehaviour
{
    [Header("Scripts")]
    Jugador ScrJugador;

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
            }

            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
    }

    
}
