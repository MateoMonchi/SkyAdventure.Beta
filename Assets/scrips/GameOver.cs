using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    // Método para cargar una escena
    public void IrAlMenu(string Menu)
    {
        try
        {
            SceneManager.LoadScene(Menu);
        }
        catch (System.Exception e)
        {
            Debug.LogError("Error al cargar la escena " + Menu + ": " + e.Message);
        }
    }

    // Método para volver a cargar el nivel 1
    public void VolverALv1()
    {
        try
        {
            SceneManager.LoadScene("Lv1");
        }
        catch (System.Exception e)
        {
            Debug.LogError("Error al cargar el nivel 1: " + e.Message);
        }
    }
}



