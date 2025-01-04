using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Collections;

public class MainMenuControllerV2 : MonoBehaviour
{
    public GameObject mainMenu; // Canvas principal
    public GameObject loadingScreen; // Canvas du loading screen
    public Slider loadingBar; // Barre de chargement
    public GameObject levelSelectionMenu; // Menu de s�lection des niveaux

    private string selectedLevel = ""; // Niveau s�lectionn�

    void Start()
    {
        // Active uniquement le menu principal au lancement
        mainMenu.SetActive(true);
        loadingScreen.SetActive(false);
        levelSelectionMenu.SetActive(false);
    }

    public void PlayGame()
    {
        // Afficher le menu de s�lection des niveaux
        mainMenu.SetActive(false);
        levelSelectionMenu.SetActive(true);
    }

    public void SelectLevel(string levelName)
    {
        // Stocker le niveau s�lectionn� et afficher l'�cran de chargement
        selectedLevel = levelName;
        levelSelectionMenu.SetActive(false);
        loadingScreen.SetActive(true);

        // D�marrer la coroutine de chargement
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
            progress += 0.01f; // Incr�menter progressivement
            loadingBar.value = progress; // Mettre � jour la barre
            yield return new WaitForSeconds(0.02f);
        }

        // Charger la sc�ne s�lectionn�e une fois le chargement termin�
        SceneManager.LoadScene(selectedLevel);
    }
}
