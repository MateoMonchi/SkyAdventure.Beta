using System.Collections;
using System.Collections.Generic;
using UnityEngine.AI;
using UnityEngine;
using System.Linq;

public class Enemigo : MonoBehaviour

{
    public float distanciaDeteccion = 5.0f;
    public float distanciaAtaque = 1.0f;
    public float tiempoEspera = 4.0f;
    public LayerMask objetivoLayer; // Capa de los objetivos a esquivar

    private Transform jugador;
    private NavMeshAgent agente;
    private bool esquivando = false;
    private float tiempoEsperado = 0f;

    void Start()
    {
        jugador = GameObject.Find("Jugador").transform;
        agente = GetComponent<NavMeshAgent>();
        tiempoEsperado = tiempoEspera;
    }

    void Update()
    {
        ComportamientoEnemigo();
    }

    void ComportamientoEnemigo()
    {
        float distanciaJugador = Vector3.Distance(transform.position, jugador.position);

        // Si el jugador está dentro del rango de detección
        if (distanciaJugador <= distanciaDeteccion)
        {
            // Seguir al jugador
            agente.SetDestination(jugador.position);

            // Si el jugador está dentro del rango de ataque
            if (distanciaJugador <= distanciaAtaque)
            {
                // Atacar al jugador (aquí puedes agregar la lógica de ataque)
            }
        }
        else
        {
            // Si el jugador no está dentro del rango de detección
            tiempoEsperado -= Time.deltaTime;
            if (tiempoEsperado <= 0)
            {
                // Buscar un objetivo para esquivar
                Vector3 direccionEsquiva = BuscarObjetivoEsquivar();
                if (direccionEsquiva != Vector3.zero)
                {
                    // Esquivar el objetivo
                    agente.SetDestination(transform.position + direccionEsquiva * 5f);
                    esquivando = true;
                    tiempoEsperado = tiempoEspera;
                }
            }
            else
            {
                // No esquivar, esperar antes de intentar esquivar nuevamente
                esquivando = false;
            }
        }
    }

    private Vector3 BuscarObjetivoEsquivar()
    {
        Vector3 direccionEsquiva = Vector3.zero;

        Collider[] objetivos = Physics.OverlapSphere(transform.position, distanciaDeteccion, objetivoLayer);
        if (objetivos.Length > 0)
        {
            // Encontrar el objetivo más cercano y esquivar en su dirección
            float distanciaMinima = Mathf.Infinity;
            foreach (Collider objetivo in objetivos)
            {
                float distancia = Vector3.Distance(transform.position, objetivo.transform.position);
                if (distancia < distanciaMinima)
                {
                    distanciaMinima = distancia;
                    direccionEsquiva = (transform.position - objetivo.transform.position).normalized;
                }
            }
        }

        return direccionEsquiva;
    }

    private void OnTriggerEnter(Collider coll)
    {
        if (coll.CompareTag("Player"))
        {
            // Llamar a la función RestarVida del jugador para hacerle daño
            coll.GetComponent<MovimientoJ>().RestarVida(10); // Ejemplo de restar 10 de vida al jugador
        }
    }

}








