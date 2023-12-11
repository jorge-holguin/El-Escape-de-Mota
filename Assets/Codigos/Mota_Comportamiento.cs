using UnityEngine;

public class Dinosaurio : MonoBehaviour
{
    public float velocidadSalto = 5f;
    public float velocidadMovimiento = 5f;
    public AudioSource sonidoSalto;

    private bool enSuelo;
    private bool haEstadoEnSuelo;
    private Rigidbody2D rb;
    private Animator anim;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    void Update()
    {
         // Verificar si ha ocurrido un clic en el lado izquierdo o derecho de la pantalla
       
    
        // Verificar si ha ocurrido un clic en la barra espaciadora
        if (Input.GetKeyDown(KeyCode.Space) && haEstadoEnSuelo)
        {
            // Clic en la barra espaciadora: saltar
            Saltar();
        }
    }

    public void SaltarDesdeBoton()
    {
        // Verificar si ha estado en el suelo antes de saltar
        if (haEstadoEnSuelo)
        {
            // Llamado desde el botón "Saltar": saltar
            Saltar();
        }
    }

    private void Saltar()
    {
        // Configuración de la animación de salto
        anim.SetTrigger("Jump");

        // Reproducir el sonido de salto
        if (sonidoSalto != null)
        {
            sonidoSalto.Play();
        }

        // Aplicar fuerza de salto al Rigidbody
        rb.velocity = new Vector2(0, velocidadSalto);
    }

    // Este método se llama cuando el objeto colisiona con otro objeto
    void OnCollisionEnter2D(Collision2D collision)
    {
        // Si colisiona con el suelo, activar la variable haEstadoEnSuelo
        if (collision.gameObject.CompareTag("Ground"))
        {
            haEstadoEnSuelo = true;
        }
    }

    // Este método se llama cuando el objeto deja de colisionar con otro objeto
    void OnCollisionExit2D(Collision2D collision)
    {
        // Si deja de colisionar con el suelo, desactivar la variable haEstadoEnSuelo
        if (collision.gameObject.CompareTag("Ground"))
        {
            haEstadoEnSuelo = false;
        }
    }
}
