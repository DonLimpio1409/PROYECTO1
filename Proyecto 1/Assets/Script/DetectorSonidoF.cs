using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class DetectorSonidoF : MonoBehaviour
{
    [SerializeField] GameObject Javier;
    DialogosNPCs dialogosNPCs;
    ControladorSFX controladorSFX;
    // Start is called before the first frame update
    void Start()
    {
        dialogosNPCs = FindObjectOfType<DialogosNPCs>();
        controladorSFX = FindObjectOfType<ControladorSFX>();
    }   

    // Update is called once per frame
    void Update()
    {

    }
    void OnTriggerEnter(Collider collision)
    {
        if (collision.CompareTag("Jugador"))
        {
            Javier.transform.position = new Vector3(-312.981f, 20.36f, -37.914f);
            Javier.transform.rotation = Quaternion.Euler(0, 121.297f, 0);
            dialogosNPCs.PuedeHablarJavier = true;
            Javier.tag = "Activable";
        }
    }
}