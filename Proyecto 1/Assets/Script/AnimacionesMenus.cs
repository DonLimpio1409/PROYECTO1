using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class AnimacionesMenus : MonoBehaviour
{
    [Header("RectTransforms")]
    RectTransform RectJugar;
    RectTransform RectOpciones;
    RectTransform RectSalir;
    RectTransform RectAtras;
    RectTransform RectSubir;
    RectTransform RectBajar;

    [Header("Botones")]
    [SerializeField] Image ITitulo;
    [SerializeField] Button BJugar;
    [SerializeField] Button BOpciones;
    [SerializeField] Button BSalir;
    [SerializeField] Button BAtras;
    [SerializeField] Button BSubir;
    [SerializeField] Button BBajar;

    [Header("Vectores")]
    Vector2 Tamaño = new Vector2(81,35);
    Vector2 NTamaño = new Vector2(90, 44);

    [Header("Scripts")]
    
    ControladorSFX controladorSFX;
    

    void Start()
    {
        RectJugar = BJugar.GetComponent<RectTransform>();
        RectOpciones = BOpciones.GetComponent<RectTransform>();   
        RectSalir = BSalir.GetComponent<RectTransform>();
        RectAtras = BAtras.GetComponent<RectTransform>();
        RectSubir = BSubir.GetComponent<RectTransform>();
        RectBajar    = BBajar.GetComponent<RectTransform>();

        controladorSFX = FindObjectOfType<ControladorSFX>();
    }

    //JUGAR
    public void CrecerJugar()
    {
        RectJugar.sizeDelta = NTamaño;
        controladorSFX.PlopBotones();
    }
    public void DeCrecerJugar()
    {
        RectJugar.sizeDelta = Tamaño; 
    }

    //OPCIONES
    public void CrecerOpciones()
    {
        RectOpciones.sizeDelta = NTamaño; 
        controladorSFX.PlopBotones();
    }
    public void DeCrecerOpciones()
    {
        RectOpciones.sizeDelta = Tamaño;
    }

    //SALIR
    public void CrecerSalir()
    {
        RectSalir.sizeDelta = NTamaño;
        controladorSFX.PlopBotones();
    }
    public void DeCrecerSalir()
    {
        RectSalir.sizeDelta = Tamaño;
    }

    //Atras
    public void CrecerAtras()
    {
        RectAtras.sizeDelta = NTamaño;
        controladorSFX.PlopBotones();
    }
    public void DeCrecerAtras()
    {
        RectAtras.sizeDelta = Tamaño; 
    }

    //Subir
    public void CrecerSubir()
    {
        RectSubir.sizeDelta = NTamaño;
        controladorSFX.PlopBotones();
    }
    public void DeCrecerSubir()
    {
        RectSubir.sizeDelta = Tamaño; 
    }
    
    //Bajar
    public void CrecerBajar()
    {
        RectBajar.sizeDelta = NTamaño;
        controladorSFX.PlopBotones();
    }
    public void DeCrecerBajar()
    {
        RectBajar.sizeDelta = Tamaño; 
    }

}
