using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestruirPaul : MonoBehaviour
{
    [SerializeField] GameObject Paul;
    // Start is called before the first frame update
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
            Paul.transform.position = new Vector3(0, 0, 200);
            Destroy(gameObject);
        }
    }
}