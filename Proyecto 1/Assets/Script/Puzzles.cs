using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Puzzles : MonoBehaviour
{
    [Header("Scripts")]
    Jugador ScrJugador;

    [Header("Posiciones Camara")]
    public GameObject camaraPuzzle;
    private Camera camaraPrincipal;
    public bool enPuzzle;
    [SerializeField] Transform posicionCamaraPuzzle;
    [SerializeField] Transform posicion2;

   

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
                case "Puzzle":
                    camaraPuzzle.transform.position = posicionCamaraPuzzle.position;
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
