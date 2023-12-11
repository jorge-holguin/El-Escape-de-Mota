using UnityEngine;
using UnityEngine.SceneManagement;

public class BotonJugar : MonoBehaviour
{
    public void OnClickJugar()
    {
        // Cargar la siguiente escena en el orden de compilación
        int siguienteIndice = SceneManager.GetActiveScene().buildIndex + 1;

        // Verificar si estamos en la última escena
        if (siguienteIndice < SceneManager.sceneCountInBuildSettings)
        {
            SceneManager.LoadScene(siguienteIndice);
        }
        else
        {
            Debug.LogWarning("¡No hay más escenas para cargar!");
        }
    }
}
