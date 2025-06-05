using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzleCajon : MonoBehaviour
{
    public int objOrganizados;

    // Start is called before the first frame update
    void Start()
    {

    }

    void Update()
    {

    }
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("SombraBoli"))
        {
            Debug.Log("Detectado");
            //Hasta aqui si funciona
            if (gameObject.name == "boli" || gameObject.name == "boli (1)")
            {
                objOrganizados++;
                gameObject.GetComponent<MecanicasPuzzle>().enabled = false;
            }
        }
    }
}
