using UnityEngine;

public class Portal : MonoBehaviour
{
    public enum TipoPortal
    {
        Subir0a1,
        Subir1a2,
        Bajar2a1,
        Bajar1a0
    }

    public TipoPortal tipo;
    public CambioDePlanta cambioDePlanta;

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.CompareTag("Jugador"))
        {
            cambioDePlanta.JugadorHaEntradoEnPortal(tipo);
        }
    }
}

