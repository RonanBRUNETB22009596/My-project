using UnityEngine;
using UnityEngine.SceneManagement;

public class VictoryMenuController : MonoBehaviour
{
    public GameObject victoryScreen; // R�f�rence au Canvas de victoire

    void Start()
    {
        // D�sactiver le menu victoire au d�but
        victoryScreen.SetActive(false);
    }

    public void ShowVictoryScreen()
    {
        // Activer le menu victoire
        victoryScreen.SetActive(true);

        // Arr�ter le temps pour que le jeu soit en pause
        Time.timeScale = 0f;
    }

    public void LoadNextLevel()
    {
        // Charger le niveau 2
        Time.timeScale = 1f; // Remettre le temps � la normale
        SceneManager.LoadScene("Level 2"); // Remplace "Level2" par le nom exact de la sc�ne
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
        Time.timeScale = 1f; // Remettre le temps � la normale
        SceneManager.LoadScene(SceneManager.GetActiveScene().name); // Recharge la sc�ne actuelle
    }
}
