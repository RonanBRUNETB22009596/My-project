using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ComingSoonManager : MonoBehaviour
{
    public GameObject comingSoonPanel; // R�f�rence au panneau "Coming Soon"

    // M�thode pour afficher le panneau
    public void ShowComingSoon()
    {
        comingSoonPanel.SetActive(true);
    }

    // M�thode pour cacher le panneau
    public void HideComingSoon()
    {
        comingSoonPanel.SetActive(false);
    }
}
