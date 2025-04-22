using UnityEngine;

public class CambioDePlanta : MonoBehaviour
{
    [Header("Posiciones")]
    [SerializeField] GameObject Subir0_1;
    public GameObject Subir1_2;
    public GameObject Bajar2_1;
    [SerializeField] GameObject Bajar1_0;

    [Header("Portales")]
    [SerializeField] Portal portal_0;
    [SerializeField] Portal portal_1;
    [SerializeField] Portal portal_2;

    [Header("")]
    public GameObject Jugador;

    [Header("Variables")]
    CharacterController cc;

    ControlCanva controlCanva;

    void Start()
    {
        cc = Jugador.GetComponent<CharacterController>();

        // Asignar este controlador a cada portal
        portal_0.cambioDePlanta = this;
        portal_1.cambioDePlanta = this;
        portal_2.cambioDePlanta = this;

        controlCanva = FindObjectOfType<ControlCanva>();
    }

    public void JugadorHaEntradoEnPortal(Portal.TipoPortal tipo)
    {
        cc.enabled = false;

        switch (tipo)
        {
            case Portal.TipoPortal.Subir0a1:
                Jugador.transform.position = Subir0_1.transform.position;
                break;

            case Portal.TipoPortal.SubirBajar1a2:
                controlCanva.DesplegarSubirBajar();
                break;
            case Portal.TipoPortal.Bajar2a1:
                Jugador.transform.position = Bajar2_1.transform.position;
                break;

            default:
                Debug.LogWarning("Tipo de portal no reconocido");
                break;
        }

        cc.enabled = true;
    }

    public void SubirPlanta()
    {
        cc.enabled = false;
        //Cambiar de planta
        Jugador.transform.position = Subir1_2.transform.position;
        cc.enabled = true;
    }

    public void BajarPlanta()
    {
        cc.enabled = false;
        //Cambio de planta
        Jugador.transform.position = Bajar1_0.transform.position;
        cc.enabled = true;
    }
}
