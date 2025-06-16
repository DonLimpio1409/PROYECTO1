using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PasaDia : MonoBehaviour
{
    Eventos eventos;
    // Start is called before the first frame update
    void Start()
    {
        eventos = FindObjectOfType<Eventos>();
    }

    // Update is called once per frame
    void Update()
    {
        if (eventos.pasapasa == true)
        {
            gameObject.GetComponent<Animator>().SetBool("PasarDia", true);
            eventos.pasapasa = false;
        }
    }
}
