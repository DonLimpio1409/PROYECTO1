using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlNpcs : MonoBehaviour
{
    public GameObject objetoTp;
    public Transform nuevaPosicion;
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

        if (other.CompareTag("Player"))
        {
            Debug.Log("¡El jugador ha tocado el Quad activadorTp!");
            objetoTp.transform.position = nuevaPosicion.position;
        }
    }


}
