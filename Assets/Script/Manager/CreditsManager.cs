using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreditsManager : MonoBehaviour
{
    public GameObject mainMenu; // R�f�rence au menu principal
    public GameObject creditsPanel; // R�f�rence au panneau des cr�dits

    public void ShowCredits()
    {
        mainMenu.SetActive(false); // Cache le menu principal
        creditsPanel.SetActive(true); // Affiche les cr�dits
    }

    public void HideCredits()
    {
        creditsPanel.SetActive(false); // Cache les cr�dits
        mainMenu.SetActive(true); // Affiche le menu principal
    }
}