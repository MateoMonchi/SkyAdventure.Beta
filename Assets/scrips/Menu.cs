using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    public void EmpezarNivel(string LV1)
    {
        SceneManager.LoadScene(LV1);
    }

  public void Salir()
    {
        Application.Quit();
        Debug.Log("Bueno pibe hasta la proxima");
    }
}
