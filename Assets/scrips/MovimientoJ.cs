using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class MovimientoJ : MonoBehaviour

{
    private new Rigidbody rigidbody;

    public float movementSpeed;
    public float jumpForce = 5f; // Fuerza del salto
    public float jumpHeight = 2f; // Altura máxima del salto
    public Vector2 sensibilidad;
    private bool isGrounded = false;

    public int vidaInicial = 100; // Vida inicial del jugador
    private int vidaActual; // Vida actual del jugador

    void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
        Cursor.lockState = CursorLockMode.Locked;

        vidaActual = vidaInicial; // Configurar la vida inicial
    }

    private void Update()
    {
        ComportamientoEnemigo();
        MovimientoJugador();
        RotarJugador();
    }

   public void ComportamientoEnemigo()
    {
        GameObject[] enemigos = GameObject.FindGameObjectsWithTag("enemy");

        foreach (GameObject enemigo in enemigos)
        {
            float distancia = Vector3.Distance(transform.position, enemigo.transform.position);

            if (distancia < 1.0f) // Aquí establece la distancia de colisión con el enemigo
            {
                print("daño");
                // Restar vida al jugador cuando colisiona con un enemigo
                RestarVida(10); // Ejemplo de restar 10 de vida al jugador
            }
        }
    }

    public void RestarVida(int cantidad)
    {
        vidaActual -= cantidad;

        // Si la vida llega a cero, el jugador muere
        if (vidaActual <= 0)
        {
            Morir();
        }
    }

    public void Morir()
    {
        if(vidaActual <= 0)
        {
            // Cargar la escena de derrota
            SceneManager.LoadScene("Derrota");
        }
        // Aquí puedes agregar cualquier lógica de muerte necesaria
        Debug.Log("El jugador ha muerto");
    }

    private void MovimientoJugador()
    {
        float hor = Input.GetAxisRaw("Horizontal");
        float ver = Input.GetAxisRaw("Vertical");

        Vector3 velocity = Vector3.zero;

        if (hor != 0 || ver != 0)
        {
            Vector3 direction = transform.forward * ver + transform.right * hor;
            velocity = direction.normalized * movementSpeed;
        }

        velocity.y = rigidbody.velocity.y;
        rigidbody.velocity = velocity;

        // Detectar la entrada de salto
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            Debug.Log("Jump");
            float jumpVelocity = Mathf.Sqrt(2 * jumpForce * jumpHeight);
            rigidbody.velocity += Vector3.up * jumpVelocity;
        }

        // Detectar si el jugador está en el suelo
        if (Physics.Raycast(transform.position, Vector3.down, 1.5f))
        {
            isGrounded = true;
        }
        else
        {
            isGrounded = false;
        }
    }

    private void RotarJugador()
    {
        float hor = Input.GetAxis("Mouse X");
        float ver = Input.GetAxis("Mouse Y");

        // Rotar horizontalmente al jugador
        transform.Rotate(Vector3.up, hor * sensibilidad.x);

        // Rotar verticalmente al jugador
        Vector3 playerRotation = transform.localEulerAngles;
        playerRotation.x -= ver * sensibilidad.y;
        transform.localEulerAngles = playerRotation;
    }
    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Muerte"))
        {
            SceneManager.LoadScene("Derrota");
        }
            
        
    }
}
