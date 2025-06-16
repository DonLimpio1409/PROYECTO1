using UnityEngine;

public class MecanicasPuzzle : MonoBehaviour
{
    private Vector3 offset;
    private float fixedY;       // Valor fijo para el eje Y
    private Puzzles ScrPuzzles; // Variable para el script Puzzles
    private Camera puzzleCamera; // Variable para la camara de puzzles
    private Renderer objetoRenderer; // Acceso al renderer del objeto
    private Color colorOriginal; // Color original del objeto
    private bool colorCambiado = false; // Flag para verificar si el color ha cambiado

    void Start()
    {
        // Encuentra el script Puzzles y la camara de puzzles
        ScrPuzzles = FindObjectOfType<Puzzles>();  // Encuentra el script Puzzles
        if (ScrPuzzles != null)
        {
            puzzleCamera = ScrPuzzles.camaraPuzzle.GetComponent<Camera>();  // Obtener el componente Camera del GameObject camaraPuzzle
        }

        // Guardamos el valor de Y que se mantendra fijo
        fixedY = transform.position.y;

        // Guardar el renderer y el color original del objeto
        objetoRenderer = GetComponent<Renderer>();
        if (objetoRenderer != null)
        {
            colorOriginal = objetoRenderer.material.color; // Guardamos el color original
        }
    }

    void Update()
    {
        /*
        // Detectar clic derecho para cambiar el color
        if (Input.GetMouseButtonDown(1))  // Boton derecho del raton
        {
            CambiarColorConClickDerecho();
        }
        */
    }

    void OnMouseDown()
    {
        if (puzzleCamera != null)
        {
            // Al hacer clic, obtenemos la posicion del raton en coordenadas del mundo
            Vector3 mouseWorld = puzzleCamera.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, puzzleCamera.WorldToScreenPoint(transform.position).z));

            // Calculamos el offset (diferencia) entre la posicion del objeto y la del rat�n
            offset = transform.position - mouseWorld;
        }
    }

    void OnMouseDrag()
    {
        if (puzzleCamera != null)
        {
            // Obtenemos la nueva posicion del raton en coordenadas del mundo
            Vector3 mouseWorld = puzzleCamera.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, puzzleCamera.WorldToScreenPoint(transform.position).z));

            // Aplicamos el offset
            Vector3 newPos = mouseWorld + offset;

            // Mantenemos la posicion Y fija
            newPos.y = fixedY;

            // Actualizamos la posicion del objeto
            transform.position = newPos;
        }
    }

    /*
    void CambiarColorConClickDerecho()
    {
        RaycastHit hit;
        Ray ray = puzzleCamera.ScreenPointToRay(Input.mousePosition); // Hacemos un rayo desde la camara hacia el punto donde se hace clic

        // Si el rayo golpea un objeto
        if (Physics.Raycast(ray, out hit))
        {
            // Verificamos si el objeto tocado es el objeto en el que estamos interesados
            if (hit.transform == transform)
            {
                if (objetoRenderer != null)
                {
                    // Cambiar el color a rojo si no se ha cambiado el color ya
                    if (!colorCambiado)
                    {
                        objetoRenderer.material.color = Color.red; // Color rojo
                        colorCambiado = true;
                    }
                    else
                    {
                        // Si el color ya se cambio, restaurarlo al color original
                        objetoRenderer.material.color = colorOriginal;
                        colorCambiado = false;
                    }
                }
            }
        }
    }
    */
}
