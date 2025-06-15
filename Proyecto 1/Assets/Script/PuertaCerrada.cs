using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PuertaCerrada : MonoBehaviour
{
    ControladorSFX ScrControladorSFX;
    Jugador ScrJugador;
    // Start is called before the first frame update
    void Start()
    {
        ScrControladorSFX = FindObjectOfType<ControladorSFX>();
        ScrJugador = FindObjectOfType<Jugador>();
    }

    // Update is called once per frame
    void Update()
    {
        if(ScrJugador.rayoAccionToca == true && ScrJugador.rayoTocando.collider.gameObject.layer == LayerMask.NameToLayer("PuertaCerrada"))
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                ScrControladorSFX.PuertaCerrada();
            }
        }
    }
}
