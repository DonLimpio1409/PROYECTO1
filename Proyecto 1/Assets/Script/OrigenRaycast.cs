using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrigenRaycast : MonoBehaviour
{
    float sensibilidadH;
    float sensibilidadV;
    float horizontal;
    float vertical;
    float verticalAux;
    Jugador ScrJugador;
    // Start is called before the first frame update
    void Start()
    {
        ScrJugador = FindObjectOfType<Jugador>();
        
        sensibilidadH = ScrJugador.sensibilidadHorizontal;
        sensibilidadV = ScrJugador.sensibilidadVertical;
    }

    // Update is called once per frame
    void Update()
    {
        Posicion();
    }

    void Posicion()
    {
        horizontal = Input.GetAxis("Mouse X") * sensibilidadH * Time.deltaTime;
        vertical = Input.GetAxis("Mouse Y") * sensibilidadV * Time.deltaTime;

        transform.Rotate(0, horizontal, 0);

        verticalAux -= vertical;
        verticalAux = Mathf.Clamp(verticalAux, -90f, 90f);

        transform.localRotation = Quaternion.Euler(verticalAux, 0, 0);
    }

}
