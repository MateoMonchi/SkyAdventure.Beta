using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ObjetosInteractuar : MonoBehaviour
{
    public Inventario inventario;

    void Start()
    {
        inventario = GameObject.FindGameObjectWithTag("Player").GetComponent<Inventario>();
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            inventario.Cantidad++;
            Destroy(gameObject);

            // Verifica si el jugador ha recogido 5 objetos para activar la escena de victoria
            if (inventario.Cantidad >= 5)
            {
                SceneManager.LoadScene("Victoria");
            }
        }
    }
}



