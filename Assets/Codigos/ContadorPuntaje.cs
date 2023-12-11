using UnityEngine;
using TMPro;

public class ContadorTiempo : MonoBehaviour
{
    public TMP_Text contadorTexto;
    private float tiempoPasado = 0f;

    void Update()
    {
        tiempoPasado += Time.deltaTime;

        // Calculate the score based on time (time * 10)
        int puntaje = Mathf.FloorToInt(tiempoPasado * 10);

        // Update the score text with leading zeros
        contadorTexto.text = puntaje.ToString("D5");
    }
}
