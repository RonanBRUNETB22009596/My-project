using UnityEngine;
using UnityEngine.SceneManagement;

public class VictoryMenuController : MonoBehaviour
{
    public GameObject victoryScreen; // Référence au Canvas de victoire

    void Start()
    {
        // Désactiver le menu victoire au début
        victoryScreen.SetActive(false);
    }

    public void ShowVictoryScreen()
    {
        // Activer le menu victoire
        victoryScreen.SetActive(true);

        // Arrêter le temps pour que le jeu soit en pause
        Time.timeScale = 0f;
    }

    public void LoadNextLevel()
    {
        // Charger le niveau 2
        Time.timeScale = 1f; // Remettre le temps à la normale
        SceneManager.LoadScene("Level 2"); // Remplace "Level2" par le nom exact de la scène
    }

    public void QuitGame()
    {
        // Quitter le jeu
        Debug.Log("Quitting game...");
        Application.Quit();
    }

    public void RetryLevel()
    {
        // Relancer le niveau actuel
        Time.timeScale = 1f; // Remettre le temps à la normale
        SceneManager.LoadScene(SceneManager.GetActiveScene().name); // Recharge la scène actuelle
    }
}
