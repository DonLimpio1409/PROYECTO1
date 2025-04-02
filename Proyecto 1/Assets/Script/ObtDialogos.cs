using System.Collections.Generic;
using UnityEngine;

public class ObtDialogos : MonoBehaviour
{
    private Dictionary<int, string[]> ExcelDialogos = new Dictionary<int, string[]>();

    void Start()
    {
        CargarCSV("Dialogos"); // Nombre del archivo sin extensión
        Debug.Log(ObtenerDialogo(1, 2));
    }

    void CargarCSV(string NombreExcel)
    {
        TextAsset csvExcel = Resources.Load<TextAsset>(NombreExcel);
        if (csvExcel == null) 
        { 
            Debug.LogError("No se encontró el archivo CSV"); return;
        }

        string[] lineas = csvExcel.text.Split('\n');

        // Empezamos desde la segunda línea para ignorar los encabezados
        for (int i = 1; i < lineas.Length; i++)
        {
            string[] values = lineas[i].Trim().Split(';'); // Trim() para evitar espacios en blanco
            
            if (values.Length < 3) // Aseguramos que hay al menos 3 columnas (ID, personaje, texto)
            {
                continue;
            }
            if (!int.TryParse(values[0], out int id)) // Evitamos líneas vacías o con ID inválido
            {
                continue;
            } 

            ExcelDialogos[id] = values;
        }
    }

    public string ObtenerDialogo(int id, int columna)
    {
        if (!ExcelDialogos.ContainsKey(id))
            return "No funciona parguela (ID no encontrado)";

        if (columna < 1 || columna >= ExcelDialogos[id].Length)
            return "No funciona parguela (Columna fuera de rango)";

        return ExcelDialogos[id][columna];
    }
}
