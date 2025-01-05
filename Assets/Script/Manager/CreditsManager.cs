using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreditsManager : MonoBehaviour
{
    public GameObject mainMenu; // Référence au menu principal
    public GameObject creditsPanel; // Référence au panneau des crédits

    public void ShowCredits()
    {
        mainMenu.SetActive(false); // Cache le menu principal
        creditsPanel.SetActive(true); // Affiche les crédits
    }

    public void HideCredits()
    {
        creditsPanel.SetActive(false); // Cache les crédits
        mainMenu.SetActive(true); // Affiche le menu principal
    }
}