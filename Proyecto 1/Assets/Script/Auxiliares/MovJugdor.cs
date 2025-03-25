using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MovJugdor : MonoBehaviour
{
    [Header("Movimiento y Gravedad")]
    [SerializeField] float velocidad;
    [SerializeField] float gravedad;

    [Header("Menu")]
    public Menu menu;
    [SerializeField] Animator animMenu;

    [Header("Mirar")]
    [SerializeField] Transform camara;
    public float sensibilidadHorizontal;
    public float sensibilidadVertical;
    float horizontal;
    float vertical;
    float verticalAux;

    [Header("Objetos/Componentes")]
    [SerializeField] Scrollbar Barra;
    CharacterController controlador;
    Vector3 VGravedad;
    
    // Start is called before the first frame update
    void Start()
    {
        controlador = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        if (menu.mirandoMenu == false)
        {
            Mover();
            Mirar();
        }
        else if(menu.mirandoMenu == true){} 
    }

    void Mover()
    {
        float moverX = Input.GetAxis("Horizontal");
        float moverZ = Input.GetAxis("Vertical");

        Vector3 move = transform.right * moverX + transform.forward * moverZ;
        controlador.Move(move * velocidad * Time.deltaTime);

        // Gravedad
        if (controlador.isGrounded && VGravedad.y < 0)
        {
            VGravedad.y = -2f;
        }

        VGravedad.y -= gravedad * Time.deltaTime;
        controlador.Move(VGravedad * Time.deltaTime);
    }

    void Mirar()
    {
        horizontal = Input.GetAxis("Mouse X") * sensibilidadHorizontal * Time.deltaTime;
        vertical = Input.GetAxis("Mouse Y") * sensibilidadVertical * Time.deltaTime;

        transform.Rotate(0, horizontal, 0);

        verticalAux -= vertical;
        verticalAux = Mathf.Clamp(verticalAux, -90f, 90f);

        camara.localRotation = Quaternion.Euler(verticalAux, 0, 0);
    }

    public void VolverAlJuego()
    {
        animMenu.SetBool("MirandoMenu", false);
        menu.mirandoMenu = false;
        Barra.enabled = false;
    }
}
