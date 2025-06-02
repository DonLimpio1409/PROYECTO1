using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Informador : MonoBehaviour
{
    [SerializeField] Animator anim;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.CompareTag("Jugador"))
        {
            anim.SetBool("HaPasado", true);
            StartCoroutine(Esperar());
        }
    }

    IEnumerator Esperar()
    {
        yield return new WaitForSeconds(2f);
        anim.SetBool("HaPasado", false);
    }
}
