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
        if(Input.GetKey(KeyCode.E) && ScrJugador.rayoAccionToca == true)
        {
            switch(ScrJugador.nombreObjActivable)
            {
                case "Presidenta":
                    textoDialogo.text = ScrDialogos.ObtenerDialogo(1, 2);
                    break;
            }
        }
    }
}
