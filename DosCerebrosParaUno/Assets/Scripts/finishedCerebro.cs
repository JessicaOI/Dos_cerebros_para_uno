using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; // Necesario para trabajar con escenas

public class ChangeSceneOnPlayersEnter : MonoBehaviour
{
    // Para mantener el estado de si cada jugador ha entrado
    private bool player1Entered = false;
    private bool player2Entered = false;

    void Update()
    {
        // Si ambos jugadores han entrado, cargamos la siguiente escena
        if (player1Entered && player2Entered)
        {
            Debug.Log("Ambos jugadores han entrado. Cargando la siguiente escena...");
            LoadNextScene();
        }
    }

    // OnTriggerEnter2D se llama cuando otro collider2D ingresa al trigger
    private void OnTriggerEnter2D(Collider2D other)
    {
        // Chequeamos si el jugador 1 ha entrado
        if (other.CompareTag("Jugador1"))
        {
            player1Entered = true;
            Debug.Log("Jugador 1 ha entrado al trigger.");
        }
        // Chequeamos si el jugador 2 ha entrado
        else if (other.CompareTag("Jugador2"))
        {
            player2Entered = true;
            Debug.Log("Jugador 2 ha entrado al trigger.");
        }
    }

    // OnTriggerExit2D se llama cuando otro collider2D sale del trigger
    private void OnTriggerExit2D(Collider2D other)
    {
        // Chequeamos si el jugador 1 ha salido
        if (other.CompareTag("Jugador1"))
        {
            player1Entered = false;
            Debug.Log("Jugador 1 ha salido del trigger.");
        }
        // Chequeamos si el jugador 2 ha salido
        else if (other.CompareTag("Jugador2"))
        {
            player2Entered = false;
            Debug.Log("Jugador 2 ha salido del trigger.");
        }
    }

    // Funci�n para cargar la siguiente escena en el listado del build
    void LoadNextScene()
    {
        // Obtenemos el �ndice de la escena actual
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        // Cargamos la siguiente escena bas�ndonos en el �ndice actual
        SceneManager.LoadScene(currentSceneIndex + 1);
    }
}
