using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Collections;

public class MainMenuControllerV2 : MonoBehaviour
{
    public GameObject mainMenu; // Canvas principal
    public GameObject loadingScreen; // Canvas du loading screen
    public Slider loadingBar; // Barre de chargement
    public GameObject levelSelectionMenu; // Menu de sélection des niveaux

    private string selectedLevel = ""; // Niveau sélectionné

    void Start()
    {
        // Active uniquement le menu principal au lancement
        mainMenu.SetActive(true);
        loadingScreen.SetActive(false);
        levelSelectionMenu.SetActive(false);
    }

    public void PlayGame()
    {
        // Afficher le menu de sélection des niveaux
        mainMenu.SetActive(false);
        levelSelectionMenu.SetActive(true);
    }

    public void SelectLevel(string levelName)
    {
        // Stocker le niveau sélectionné et afficher l'écran de chargement
        selectedLevel = levelName;
        levelSelectionMenu.SetActive(false);
        loadingScreen.SetActive(true);

        // Démarrer la coroutine de chargement
        StartCoroutine(LoadLevelAsync());
    }

    public void BackToMainMenu()
    {
        // Revenir au menu principal
        levelSelectionMenu.SetActive(false);
        mainMenu.SetActive(true);
    }

    public void QuitGame()
    {
        Debug.Log("Quitting game...");
        Application.Quit();
    }

    IEnumerator LoadLevelAsync()
    {
        // Simuler un chargement progressif
        float progress = 0;
        while (progress < 1)
        {
            progress += 0.01f; // Incrémenter progressivement
            loadingBar.value = progress; // Mettre à jour la barre
            yield return new WaitForSeconds(0.02f);
        }

        // Charger la scène sélectionnée une fois le chargement terminé
        SceneManager.LoadScene(selectedLevel);
    }
}
