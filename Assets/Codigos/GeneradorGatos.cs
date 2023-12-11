using UnityEngine;

public class GeneradorGatosVoladores : MonoBehaviour
{
    public GameObject gatoVoladorPrefab;
    public float tiempoMinimoGeneracion = 0.5f;
    public float tiempoMaximoGeneracion = 1f;
    public float rangoVariacionY = 1.0f;

    void Start()
    {
        // Llamar a la función de generación en intervalos aleatorios
        InvokeRepeating("GenerarGatoVolador", Random.Range(tiempoMinimoGeneracion, tiempoMaximoGeneracion), Random.Range(tiempoMinimoGeneracion, tiempoMaximoGeneracion));
    }

    void GenerarGatoVolador()
    {
        // Calcular una posición Y dentro del rango de variación, relativa a la posición actual
        float posicionY = transform.position.y + Random.Range(-rangoVariacionY, rangoVariacionY);

        // Instanciar el Prefab del gato volador en la posición del objeto de generación
        GameObject gatoVolador = Instantiate(gatoVoladorPrefab, new Vector2(transform.position.x, posicionY), Quaternion.identity);

        // Obtener el componente Rigidbody2D y configurarlo como Kinematic
        Rigidbody2D rbGato = gatoVolador.GetComponent<Rigidbody2D>();
        if (rbGato != null)
        {
            rbGato.bodyType = RigidbodyType2D.Kinematic;
        }
    }
}
