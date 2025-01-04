using UnityEngine;
using UnityEngine.SceneManagement;

public class DeathMenuController : MonoBehaviour
{
    public GameObject deathScreen; // Le Panel du menu de mort

    public void ShowDeathScreen()
    {
        if (deathScreen != null)
        {
            deathScreen.SetActive(true); // Active le menu de mort
        }
        else
        {
            Debug.LogError("Death Screen is not assigned in the inspector!");
        }
    }

    public void OnResetButton()
    {
        // Réinitialise la scène actuelle
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void OnOptionsButton()
    {
        // Placeholder pour les options (à implémenter)
        Debug.Log("Options menu not implemented yet.");
    }

    public void OnLeaveButton()
    {
        // Quitte l'application
        Debug.Log("Quitting game...");
        Application.Quit();
    }
}
