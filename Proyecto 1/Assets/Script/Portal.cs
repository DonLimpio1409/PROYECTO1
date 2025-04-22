using UnityEngine;

public class Portal : MonoBehaviour
{
    public enum TipoPortal
    {
        Subir0a1,
        SubirBajar1a2,
        Bajar2a1
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

