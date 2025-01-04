using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TrophyInteraction : MonoBehaviour
{
    public VictoryMenuController victoryMenuController; // Référence au contrôleur du menu de victoire

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Trophy collected! Showing victory menu.");
            victoryMenuController.ShowVictoryScreen(); // Affiche le menu de victoire
            Destroy(gameObject); // Supprime le trophée après collecte
        }
    }
}
