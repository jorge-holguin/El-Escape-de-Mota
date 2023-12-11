using UnityEngine;
using UnityEngine.SceneManagement;

public class CactusController : MonoBehaviour
{
    public float velocidadBase = 5f;
    public float aumentoVelocidad = 0.1f;
    public float intervaloAumento = 5f;

    private float tiempoTranscurrido = 0f;
    private float velocidadActual;

    void Start()
    {
        // Iniciar el movimiento del cactus con la velocidad base
        velocidadActual = velocidadBase;
        MoverCactus();
    }

    void Update()
    {
        // Destruir el cactus si sale del área visible
        if (transform.position.x < -15f)
        {
            Destroy(gameObject);
        }

        // Aumentar la velocidad gradualmente cada intervalo de tiempo
        tiempoTranscurrido += Time.deltaTime;
        if (tiempoTranscurrido >= intervaloAumento)
        {
            AumentarVelocidad();
            tiempoTranscurrido = 0f; // Reiniciar el contador
        }
    }

    void AumentarVelocidad()
    {
        // Aumentar la velocidad
        velocidadActual += aumentoVelocidad;

        // Mover el cactus con la nueva velocidad
        MoverCactus();
    }

    void MoverCactus()
    {
        // Mover el cactus con la velocidad actual
        Rigidbody2D rb = GetComponent<Rigidbody2D>();
        rb.velocity = new Vector2(-velocidadActual, 0f);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        // Verificar si el jugador colisionó con el cactus
        if (other.CompareTag("Player"))
        {
            // Aquí puedes agregar lógica para manejar la colisión con el jugador
            // Por ejemplo, mostrar un mensaje de game over, reiniciar el juego, etc.
            Debug.Log("Game Over");

            // Reiniciar la escena
            SceneManager.LoadScene(0);
        }
    }
}
