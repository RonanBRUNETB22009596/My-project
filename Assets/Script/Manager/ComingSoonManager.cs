using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ComingSoonManager : MonoBehaviour
{
    public GameObject comingSoonPanel; // Référence au panneau "Coming Soon"

    // Méthode pour afficher le panneau
    public void ShowComingSoon()
    {
        comingSoonPanel.SetActive(true);
    }

    // Méthode pour cacher le panneau
    public void HideComingSoon()
    {
        comingSoonPanel.SetActive(false);
    }
}
