using UnityEngine;

public class MecanicasPuzzle : MonoBehaviour
{
    private Vector3 offset;
    private float fixedY;       // Valor fijo para el eje Y
    private Puzzles ScrPuzzles; // Variable para el script Puzzles
    private Camera puzzleCamera; // Variable para la c�mara de puzzles
    private Renderer objetoRenderer; // Acceso al renderer del objeto
    private Color colorOriginal; // Color original del objeto
    private bool colorCambiado = false; // Flag para verificar si el color ha cambiado

    void Start()
    {
        // Encuentra el script Puzzles y la c�mara de puzzles
        ScrPuzzles = FindObjectOfType<Puzzles>();  // Encuentra el script Puzzles
        if (ScrPuzzles != null)
        {
            puzzleCamera = ScrPuzzles.camaraPuzzle.GetComponent<Camera>();  // Obt�n el componente Camera del GameObject camaraPuzzle
        }

        // Guardamos el valor de Y que se mantendr� fijo
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
        // Detectar clic derecho para cambiar el color
        if (Input.GetMouseButtonDown(1))  // Bot�n derecho del rat�n
        {
            CambiarColorConClickDerecho();
        }
    }

    void OnMouseDown()
    {
        if (puzzleCamera != null)
        {
            // Al hacer clic, obtenemos la posici�n del rat�n en coordenadas del mundo
            Vector3 mouseWorld = puzzleCamera.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, puzzleCamera.WorldToScreenPoint(transform.position).z));

            // Calculamos el offset (diferencia) entre la posici�n del objeto y la del rat�n
            offset = transform.position - mouseWorld;
        }
    }

    void OnMouseDrag()
    {
        if (puzzleCamera != null)
        {
            // Obtenemos la nueva posici�n del rat�n en coordenadas del mundo
            Vector3 mouseWorld = puzzleCamera.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, puzzleCamera.WorldToScreenPoint(transform.position).z));

            // Aplicamos el offset
            Vector3 newPos = mouseWorld + offset;

            // Mantenemos la posici�n Y fija
            newPos.y = fixedY;

            // Actualizamos la posici�n del objeto
            transform.position = newPos;
        }
    }

    void CambiarColorConClickDerecho()
    {
        RaycastHit hit;
        Ray ray = puzzleCamera.ScreenPointToRay(Input.mousePosition); // Hacemos un rayo desde la c�mara hacia el punto donde se hace clic

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
                        // Si el color ya se cambi�, restaurarlo al color original
                        objetoRenderer.material.color = colorOriginal;
                        colorCambiado = false;
                    }
                }
            }
        }
    }
}
