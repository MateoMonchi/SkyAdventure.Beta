using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Codigo_Pausa : MonoBehaviour
{
    public GameObject ObjetoMenuPausa;
    public bool Pausa = false;
    public GameObject MenuSalir;
    void Start()
    {
        
    }


    void Update()
    {
        if(Input.GetKey(KeyCode.Escape))
        {
            if(Pausa == false) 
            { 
            ObjetoMenuPausa.SetActive(true);
            Pausa = true;
                Time.timeScale = 0;
                Cursor.visible = true;
                Cursor.lockState = CursorLockMode.None;
            }
        }
        
    }
    public void Resumir()
    {
        ObjetoMenuPausa.SetActive(false);
        MenuSalir.SetActive(false);
        Pausa = false;
        
        Time.timeScale = 1;
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;

    }
    public void IrAlMenu(string Menu)
    {
        SceneManager.LoadScene(Menu);
    }
    public void SalirDelJuego()
    {
        Application.Quit();
    }
}
