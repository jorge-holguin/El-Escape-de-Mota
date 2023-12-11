using UnityEngine;

public class FondoInfinito : MonoBehaviour
{
    public float velocidad = 5f;
    private float anchoFondo;

    void Start()
    {
        // Obtener el ancho del fondo
        anchoFondo = ObtenerAnchoDelFondo();
    }

    void Update()
    {
        // Mover el fondo en dirección opuesta al eje X con la velocidad actual
        transform.Translate(Vector2.left * velocidad * Time.deltaTime);

        // Verificar si el fondo ha salido completamente de la pantalla
        if (transform.position.x < -anchoFondo)
        {
            // Reposicionar el fondo al lado derecho
            ReposicionarFondo();
        }
    }

    void ReposicionarFondo()
    {
        // Calcular la nueva posición del fondo al lado derecho
        Vector3 nuevaPosicion = new Vector3(transform.position.x + anchoFondo * 2, transform.position.y, transform.position.z);

        // Reposicionar el fondo
        transform.position = nuevaPosicion;
    }

    // Método para obtener el ancho del fondo
    float ObtenerAnchoDelFondo()
    {
        SpriteRenderer spriteRenderer = GetComponent<SpriteRenderer>();
        return spriteRenderer.bounds.size.x;
    }
}
