using UnityEngine;

public class CambioDePlanta : MonoBehaviour
{
    [Header("Posiciones")]
    [SerializeField] GameObject Subir0_1;
    [SerializeField] GameObject Subir1_2;
    [SerializeField] GameObject Bajar2_1;
    [SerializeField] GameObject Bajar1_0;

    [Header("Portales")]
    [SerializeField] Portal portal_0;
    [SerializeField] Portal portalSubir_1;
    [SerializeField] Portal portalBajar_1;
    [SerializeField] Portal portal_2;

    [Header("")]
    [SerializeField] GameObject Jugador;

    [Header("Variables")]
    CharacterController cc;

    void Start()
    {
        cc = Jugador.GetComponent<CharacterController>();

        // Asignar este controlador a cada portal
        portal_0.cambioDePlanta = this;
        portalSubir_1.cambioDePlanta = this;
        portalBajar_1.cambioDePlanta = this;
        portal_2.cambioDePlanta = this;
    }

    public void JugadorHaEntradoEnPortal(Portal.TipoPortal tipo)
    {
        cc.enabled = false;

        switch (tipo)
        {
            case Portal.TipoPortal.Subir0a1:
                Jugador.transform.position = Subir0_1.transform.position;
                break;

            case Portal.TipoPortal.Subir1a2:
                Jugador.transform.position = Subir1_2.transform.position;
                break;

            case Portal.TipoPortal.Bajar2a1:
                Jugador.transform.position = Bajar2_1.transform.position;
                break;

            case Portal.TipoPortal.Bajar1a0:
                Jugador.transform.position = Bajar1_0.transform.position;
                break;

            default:
                Debug.LogWarning("Tipo de portal no reconocido");
                break;
        }

        cc.enabled = true;
    }
}
