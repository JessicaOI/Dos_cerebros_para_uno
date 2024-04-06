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
            LoadNextScene();
        }
    }

    // OnTriggerEnter se llama cuando otro collider ingresa al trigger
    private void OnTriggerEnter(Collider other)
    {
        // Chequeamos si el jugador 1 ha entrado
        if (other.CompareTag("Jugador1"))
        {
            player1Entered = true;
        }
        // Chequeamos si el jugador 2 ha entrado
        else if (other.CompareTag("Jugador2"))
        {
            player2Entered = true;
        }
    }

    // OnTriggerExit se llama cuando otro collider sale del trigger
    private void OnTriggerExit(Collider other)
    {
        // Chequeamos si el jugador 1 ha salido
        if (other.CompareTag("Jugador1"))
        {
            player1Entered = false;
        }
        // Chequeamos si el jugador 2 ha salido
        else if (other.CompareTag("Jugador2"))
        {
            player2Entered = false;
        }
    }

    // Función para cargar la siguiente escena en el listado del build
    void LoadNextScene()
    {
        // Obtenemos el índice de la escena actual
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        // Cargamos la siguiente escena basándonos en el índice actual
        SceneManager.LoadScene(currentSceneIndex + 1);
    }
}
