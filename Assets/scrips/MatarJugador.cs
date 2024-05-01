using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MatarJugador : MonoBehaviour

{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            // Llamar a la funci�n de muerte del jugador si est� en el mismo GameObject
            other.GetComponent<MovimientoJ>().Morir();
        }
    }
}


