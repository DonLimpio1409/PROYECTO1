using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Limpiador : MonoBehaviour
{
    [Header("Scripts")]
    ControlCanva controlCanva;

    [Header("Objetos a destruir")]

    [SerializeField] GameObject Exterior1;
    [SerializeField] GameObject Exterior2;
    [SerializeField] GameObject Exterior3;
    [SerializeField] GameObject Exterior4;
    [SerializeField] GameObject Exterior5;
    void Start()
    {
        controlCanva = FindObjectOfType<ControlCanva>();
    }

    // Update is called once per frame
    void Update()
    {
        if(controlCanva.estaJugando == true)
        {
            Destroy(Exterior1);
            Destroy(Exterior2);
            Destroy(Exterior3);
            Destroy(Exterior4);
            Destroy(Exterior5);
        }
    }
}
