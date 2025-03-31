using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TpObjNpc : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] GameObject objetoTp;
    [SerializeField] Transform nuevaPosicion;
    public bool usado = false;
    public bool puedeUsarse = false;

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("La consola está funcionando correctamente");
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerExit(Collider other)
    {

        if (other.CompareTag("Jugador"))
        {
            Debug.Log("¡El jugador ha tocado el Quad activadorTp!");
            objetoTp.transform.position = nuevaPosicion.position;
            gameObject.SetActive(false);
            usado = true;
        }
    }

    private void OnMouseDown()
    {
        if (puedeUsarse)
        {
            if (gameObject.CompareTag("Puerta"))
            {
                objetoTp.transform.position = nuevaPosicion.position;

            }
        }
        
    }
}
