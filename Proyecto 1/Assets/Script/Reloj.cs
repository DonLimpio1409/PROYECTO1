using UnityEngine;

public class Reloj : MonoBehaviour
{
    [Range(0, 23)] public int hora = 0;  // Hora del juego (0-23)
    [Range(0, 59)] public int minutos = 0; // Minutos del juego (0-59)
    public float segundos = 0f; // Segundos en decimal para precisi�n
    

    public string reloj;

    public float velocidadTiempo = 60f; // 1 = tiempo real, 60 = 1 segundo real equivale a 1 minuto en el juego

    void Update()
    {
        // Avanzar el tiempo del juego
        segundos += Time.deltaTime * velocidadTiempo;


        // Asegurarse de que los segundos pasen correctamente
        if (segundos >= 60)
        {
            int minutosExtra = (int)(segundos / 60); // Cu�ntos minutos se deben agregar
            segundos -= minutosExtra * 60; // Restamos los minutos que ya se sumaron
            minutos += minutosExtra;

            if (minutos >= 60)
            {
                int horasExtra = minutos / 60;
                minutos %= 60; // Nos quedamos solo con los minutos restantes
                hora += horasExtra;

                if (hora >= 24)
                {
                    hora %= 24; // Reinicia el d�a
                }
            }
        }

        ObtenerHora();
        //Debug.Log("Hora en el juego: " + reloj);
    }

    // Formatear la hora en HH:MM:SS
    public void ObtenerHora()
    {
        // Formatear la hora en HH:MM:SS usando los segundos decimales
        reloj = string.Format("{0:00}:{1:00}:{2:00}", hora, minutos, (int)segundos);
    }
}
