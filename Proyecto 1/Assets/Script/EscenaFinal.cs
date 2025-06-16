using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EscenaFinal : MonoBehaviour
{
    [SerializeField] GameObject FondoNegro;    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {

    }
    
    void OnTriggerEnter(Collider collision)
    {
        if (collision.CompareTag("Jugador"))
        {
            FondoNegro.SetActive(true);
        }
    }
}
