using UnityEngine;
using UnityEngine.SceneManagement;

public class DeathScreenController : MonoBehaviour
{
    public GameObject deathScreen; // Référence au Canvas de mort

    void Start()
    {
        // Désactiver le menu Game Over au début
        if (deathScreen != null)
        {
            deathScreen.SetActive(false);
        }
    }

    public void ShowDeathScreen()
    {
        // Activer le menu Game Over
        if (deathScreen != null)
        {
            deathScreen.SetActive(true);
            Time.timeScale = 0f; // Met le jeu en pause
        }
        Debug.Log("ShowDeathScreen called!");
    }

    public void RetryLevel()
    {
        // Relancer le niveau actuel
        Time.timeScale = 1f; // Remet le temps à la normale
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void QuitGame()
    {
        // Quitter le jeu
        Debug.Log("Quitting game...");
        Application.Quit();
    }

    public void GoToMainMenu()
    {
        // Retourner au menu principal
        Time.timeScale = 1f; // Remet le temps à la normale
        SceneManager.LoadScene("MainMenu"); 
    }


}
