using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SombrasCajon : MonoBehaviour
{
    [SerializeField] GameObject boli;
    [SerializeField] GameObject boli1;
    [SerializeField] GameObject lapiz;
    [SerializeField] GameObject lapiz1;
    [SerializeField] GameObject polo;
    [SerializeField] GameObject sueter;
    [SerializeField] GameObject falda;

    public int objOrganizados;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Boli"))
        {
            boli.GetComponent<BoxCollider>().enabled = false;
            objOrganizados++;
        }
        if (other.CompareTag("Boli1"))
        {
            boli1.GetComponent<BoxCollider>().enabled = false;
            objOrganizados++;
        }
        if (other.CompareTag("Lapiz"))
        {
            lapiz.GetComponent<BoxCollider>().enabled = false;
            objOrganizados++;
        }
        if (other.CompareTag("Lapiz1"))
        {
            lapiz1.GetComponent<BoxCollider>().enabled = false;
            objOrganizados++;
        }
        if (other.CompareTag("Sueter"))
        {
            sueter.GetComponent<BoxCollider>().enabled = false;
            objOrganizados++;
        }
        if (other.CompareTag("Polo"))
        {
            polo.GetComponent<BoxCollider>().enabled = false;
            objOrganizados++;
        }
        if (other.CompareTag("Falda"))
        {
            falda.GetComponent<BoxCollider>().enabled = false;
            objOrganizados++;
        }
    }
}
