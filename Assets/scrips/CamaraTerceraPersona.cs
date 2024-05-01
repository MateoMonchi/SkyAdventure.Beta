using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamaraTerceraPersona : MonoBehaviour


{
    public Transform objetivo; // El jugador
    public float distancia = 5.0f; // Distancia de la cámara al jugador
    public float altura = 2.0f; // Altura de la cámara sobre el jugador
    public float sensibilidadX = 2.0f; // Sensibilidad de rotación horizontal
    public float sensibilidadY = 1.0f; // Sensibilidad de rotación vertical
    public float anguloMinY = -50.0f; // Ángulo mínimo de rotación vertical
    public float anguloMaxY = 80.0f; // Ángulo máximo de rotación vertical

    private float rotacionX = 0.0f;
    private float rotacionY = 0.0f;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked; // Bloquear el cursor
        Cursor.visible = false; // Hacer que el cursor sea invisible

        // Si no se asigna un objetivo, intenta encontrar el jugador en la escena
        if (objetivo == null)
        {
            objetivo = GameObject.FindGameObjectWithTag("Player").transform;
        }
    }

    void LateUpdate()
    {
        if (objetivo == null)
            return; // Si no hay un objetivo, no hacer nada

        // Obtener la entrada del ratón
        float mouseX = Input.GetAxis("Mouse X") * sensibilidadX;
        float mouseY = Input.GetAxis("Mouse Y") * sensibilidadY;

        // Aplicar la rotación horizontal al objetivo
        rotacionX += mouseX;
        objetivo.Rotate(Vector3.up * mouseX);

        // Aplicar la rotación vertical a la cámara
        rotacionY -= mouseY;
        rotacionY = Mathf.Clamp(rotacionY, anguloMinY, anguloMaxY);
        transform.localRotation = Quaternion.Euler(rotacionY, rotacionX, 0.0f);

        // Posicionar la cámara detrás y sobre el jugador
        Vector3 direccion = new Vector3(0.0f, altura, -distancia);
        Quaternion rotacion = Quaternion.Euler(rotacionY, rotacionX, 0.0f);
        transform.position = objetivo.position + rotacion * direccion;
        transform.LookAt(objetivo.position);
    }
}




