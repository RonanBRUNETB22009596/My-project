using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ComingSoonAnimation : MonoBehaviour
{
    public Text comingSoonText; // Référence au texte "Coming Soon..."
    private string baseText = "Coming Soon"; // Texte de base
    private float timer = 0f; // Timer pour l'animation
    private int dotCount = 0; // Compteur pour les points

    void Update()
    {
        // Ajoutez un point toutes les 0,5 secondes
        timer += Time.deltaTime;
        if (timer >= 0.5f)
        {
            timer = 0f;
            dotCount = (dotCount + 1) % 4; // Alterne entre 0, 1, 2, 3
            comingSoonText.text = baseText + new string('.', dotCount); // Ajoute les points au texte
        }
    }
}