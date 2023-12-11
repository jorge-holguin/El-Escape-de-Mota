using UnityEngine;

public class GeneradorCactus : MonoBehaviour
{
    public GameObject cactusPrefab;
    public float tiempoMinimoGeneracion = 1f;
    public float tiempoMaximoGeneracion = 2f;

    void Start()
    {
        // Llamar a la función de generación en intervalos aleatorios
        InvokeRepeating("GenerarCactus", 0f, Random.Range(tiempoMinimoGeneracion, tiempoMaximoGeneracion));
    }

    void GenerarCactus()
    {
        // Instanciar el Prefab del cactus en el mismo eje X (sin variación en Y)
        Instantiate(cactusPrefab, new Vector2(transform.position.x, transform.position.y), Quaternion.identity);
    }
}
