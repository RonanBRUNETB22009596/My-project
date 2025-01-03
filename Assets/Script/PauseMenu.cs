using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public GameObject pauseMenuUI; // R�f�rence au GameObject du menu pause

    private bool isPaused = false;

    void Update()
    {
        // Ouvre/ferme le menu pause en appuyant sur �chap
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isPaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
    }

    // Active le menu pause
    public void Pause()
    {
        pauseMenuUI.SetActive(true); // Affiche le menu pause
        Time.timeScale = 0f;        // Met le jeu en pause
        isPaused = true;
    }

    // Reprend le jeu
    public void Resume()
    {
        pauseMenuUI.SetActive(false); // Cache le menu pause
        Time.timeScale = 1f;          // Reprend le temps du jeu
        isPaused = false;
    }

    // R�initialise le niveau
    public void ResetLevel()
    {
        Time.timeScale = 1f; // Reprend le temps avant de recharger
        SceneManager.LoadScene(SceneManager.GetActiveScene().name); // Recharge la sc�ne actuelle
    }

    // Quitte le jeu (optionnel)
    public void QuitGame()
    {
        Debug.Log("Quitter le jeu");
        Application.Quit(); // Fonctionne uniquement dans une build
    }
}