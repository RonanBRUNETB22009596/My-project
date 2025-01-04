using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TrophyInteraction : MonoBehaviour
{
    public VictoryMenuController victoryMenuController; // R�f�rence au contr�leur du menu de victoire

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Trophy collected! Showing victory menu.");
            victoryMenuController.ShowVictoryScreen(); // Affiche le menu de victoire
            Destroy(gameObject); // Supprime le troph�e apr�s collecte
        }
    }
}
