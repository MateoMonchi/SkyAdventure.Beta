using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotar : MonoBehaviour


{
    public float rotationSpeed = 10f; // Velocidad de rotación en grados por segundo

    void Update()
    {
        // Rotar el objeto alrededor de su eje Y
        transform.Rotate(Vector3.up, rotationSpeed * Time.deltaTime);
    }
}


