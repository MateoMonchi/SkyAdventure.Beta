using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;



public class DeVictoriaAMenu : MonoBehaviour
{
    // Método para cargar la escena del menú
    public void VolverAlMenu(string Menu)
    {
        // Verificar si el nombre de la escena es válido
        if (string.IsNullOrEmpty(Menu))
        {
            Debug.LogError("Nombre de escena inválido.");
            return;
        }

        // Verificar si la escena a cargar existe en el build settings
        if (!EscenaExiste(Menu))
        {
            Debug.LogError("La escena '" + Menu + "' no existe en el build settings.");
            return;
        }

        // Cargar la escena del menú
        SceneManager.LoadScene(Menu);
    }

    // Método para verificar si una escena existe en el build settings
    private bool EscenaExiste(string nombreDeEscena)
    {
        for (int i = 0; i < SceneManager.sceneCountInBuildSettings; i++)
        {
            string nombre = System.IO.Path.GetFileNameWithoutExtension(SceneUtility.GetScenePathByBuildIndex(i));
            if (nombreDeEscena == nombre)
                return true;
        }
        return false;
    }
}

