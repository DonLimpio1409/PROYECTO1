using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PasaDia : MonoBehaviour
{
    Eventos eventos;
    public int VpasaDia = 0;

    [SerializeField] GameObject lanzador;
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
            VpasaDia++;
            gameObject.GetComponent<Animator>().SetBool("PasarDia", true);
            StartCoroutine(Esperar());
            eventos.pasapasa = false;
        }
        if (VpasaDia == 2)
        {
            lanzador.SetActive(true);
        }
    }

    IEnumerator Esperar()
    {
        yield return new WaitForSeconds(4.5f);
        gameObject.GetComponent<Animator>().SetBool("PasarDia", false);
    }
}
