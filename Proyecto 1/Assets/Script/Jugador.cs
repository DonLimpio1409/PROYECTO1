using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

public class Jugador : MonoBehaviour
{
    [Header("Movimiento y Gravedad")]
    [SerializeField] float velocidad;
    [SerializeField] float gravedad;

    [Header("Mirar")]
    [SerializeField] Transform camara;
    public float sensibilidadHorizontal;
    public float sensibilidadVertical;
    private float horizontal;
    private float vertical;
    private float verticalAux;

    [Header("Objetos/Componentes")]
    public bool manoLlena;
    CharacterController controlador;
    Vector3 VGravedad;
    [SerializeField] GameObject ObjetoEnMano;
    [SerializeField] GameObject OrigenRaycast;

    [Header("Posiciones")]
    [SerializeField] GameObject manoVacia;
    [SerializeField] GameObject dejarObjeto;
    public GameObject ObjMano;
    GameObject ObjOriginal;

    [Header("Accion")]
    public bool rayoAccionToca;
    public GameObject textoAccion;
    public string nombreObjActivable;
    public RaycastHit rayoTocando;

    [Header("Puzzle")]
    public bool rayoPuzzleToca;
    public string nombrePuzzle;

    [Header("Scripts")]
    ControlCanva ScrControlCanva;
    Puzzles ScrPuzzles;

    [Header("Control de Hit")]
    public GameObject objetoContactado;

    // Start is called before the first frame update
    void Start()
    {

        controlador = GetComponent<CharacterController>();

        ScrControlCanva = FindObjectOfType<ControlCanva>();
        ScrPuzzles = FindObjectOfType<Puzzles>();
    }

    // Update is called once per frame
    void Update()
    {
        //Se a dado a jugar y no estas en un puzzle
        if (ScrControlCanva.estaJugando == true && ScrPuzzles.enPuzzle == false)
        {
            Mirar();
            Mover();
            CentrarRaton();

            //Cojer y dejar Objetos
            CogerObjeto();
            DejarObjeto();

            Accion();
            TocarPuzzle();
        }
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

    public void CentrarRaton()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }


    void CogerObjeto()
    {
        //Cojer Objetos
        if (Input.GetMouseButton(0))
        {
            RaycastHit rayoTocando;
            Vector3 direccion = camara.transform.forward; //Siempre hacia delante pero en un vertor 3 para tener en cuenta la rotacion
            Vector3 origen = OrigenRaycast.transform.position; //Lo mismo del vector
            float alcanceCoger = 2f;

            Ray rayoCoger = new Ray(origen, direccion);//Definir RayCast de coger

            Debug.DrawRay(origen, direccion * alcanceCoger, Color.red);//Dibujar raycast

            if (Physics.Raycast(rayoCoger, out rayoTocando, alcanceCoger))//Lanzamos un RayCast
            {
                if (rayoTocando.collider.gameObject.CompareTag("ObjInteractuable") && manoLlena == false)
                {
                    ObjOriginal = rayoTocando.collider.gameObject;

                    ObjOriginal.transform.position = manoVacia.transform.position;

                    ObjOriginal.transform.SetParent(manoVacia.transform);

                    ObjOriginal.GetComponent<BoxCollider>().enabled = false;

                    ObjMano = ObjOriginal;

                    manoLlena = true;
                }

            }
        }
    }

    void DejarObjeto()
    {
        //Dejar Objetos
        if (Input.GetMouseButton(1))
        {
            RaycastHit rayoTocando;
            Vector3 direccion = camara.transform.forward; //Siempre hacia delante pero en un vertor 3 para tener en cuenta la rotacion
            Vector3 origen = OrigenRaycast.transform.position; //Lo mismo del vector
            float alcanceDejar = 5f;

            Ray rayoDejar = new Ray(origen, direccion);//Definir RayCast de dejar

            Debug.DrawRay(origen, direccion * alcanceDejar, Color.yellow);//Dibujar raycast

            if (Physics.Raycast(rayoDejar, out rayoTocando, alcanceDejar))//Lanzamos un RayCast
            {
                if (rayoTocando.collider.gameObject.CompareTag("Suelo"))
                {
                    dejarObjeto.transform.position = rayoTocando.point;//Transportar el Dejar Objeto al punto de choque del raycast dejar
                    ObjMano.GetComponent<BoxCollider>().enabled = true;//Activamos el collider del obj que dejamos
                    ObjMano.transform.position = dejarObjeto.transform.position;
                    ObjMano.transform.SetParent(null);
                    ObjMano = null;
                    manoLlena = false;
                }
            }
        }
    }

    public void Accion()
    {
        Vector3 direccion = camara.transform.forward; //Siempre hacia delante pero en un vertor 3 para tener en cuenta la rotacion
        Vector3 origen = OrigenRaycast.transform.position; //Lo mismo del vector
        float alcanceDejar = 2f;


        Ray rayoDejar = new Ray(origen, direccion);//Definir RayCast de dejar

        Debug.DrawRay(origen, direccion * alcanceDejar, Color.blue);//Dibujar raycast

        if (Physics.Raycast(rayoDejar, out rayoTocando, alcanceDejar))//Lanzamos el rayo de manera constante
        {

            if (rayoTocando.collider.gameObject.CompareTag("Activable"))
            {
                rayoAccionToca = true;
                nombreObjActivable = rayoTocando.collider.gameObject.name;
                textoAccion.SetActive(true);

            }
            else
            {
                rayoAccionToca = false;
                nombreObjActivable = null;
                textoAccion.SetActive(false);
            }
        }
        else
        {
            // Si el raycast no toca nada, desactiva la acci�n 
            rayoAccionToca = false;
            nombreObjActivable = null;
            textoAccion.SetActive(false);
        }
    }

    void TocarPuzzle()
    {
        RaycastHit rayoTocando;
        Vector3 direccion = camara.transform.forward; //Siempre hacia delante pero en un vertor 3 para tener en cuenta la rotacion
        Vector3 origen = OrigenRaycast.transform.position; //Lo mismo del vector
        float alcanceDejar = 2f;


        Ray rayoDejar = new Ray(origen, direccion);//Definir RayCast de dejar

        Debug.DrawRay(origen, direccion * alcanceDejar, Color.green);//Dibujar raycast

        if (Physics.Raycast(rayoDejar, out rayoTocando, alcanceDejar))//Lanzamos el rayo de manera constante
        {
            if (rayoTocando.collider.gameObject.CompareTag("Puzzle"))
            {
                rayoPuzzleToca = true;
                nombrePuzzle = rayoTocando.collider.gameObject.name;
            }

            else
            {
                rayoPuzzleToca = false;
                nombrePuzzle = null;
            }

        }
        else
        {
            // Si el raycast no toca nada, desactiva la accion de tocar el puzzle
            rayoPuzzleToca = false;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        objetoContactado = other.gameObject;
    }
}
