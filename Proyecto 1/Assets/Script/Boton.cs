using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Boton : MonoBehaviour
{
    [SerializeField] TMP_InputField ImputContraseña;
    [SerializeField] GameObject imputContraseña;
    [SerializeField] GameObject BotonConfimar;
    [SerializeField] string contraseña = "80658576";
    public bool confirmacion = false;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void Confirmado()
    {
        if (ImputContraseña.text == contraseña)
        {
            confirmacion = true;
            new WaitForEndOfFrame();
            imputContraseña.SetActive(false);
            BotonConfimar.SetActive(false);
            ImputContraseña.text = "";
        }
    }
}
