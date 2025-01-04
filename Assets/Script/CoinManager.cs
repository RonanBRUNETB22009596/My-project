using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CoinManager : MonoBehaviour
{
    public static CoinManager Instance; // Instance pour un accès global
    public Text coinText;               // Référence au texte UI pour le compteur

    private int coinCount = 0;          // Compteur des pièces

    void Awake()
    {
        // S'assurer qu'une seule instance existe
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {
        UpdateUI();
    }

    // Méthode pour ajouter une pièce
    public void AddCoin()
    {
        coinCount++;
        UpdateUI();
    }

    // Met à jour le texte UI
    private void UpdateUI()
    {
        if (coinText != null)
        {
            coinText.text = $"Pièces : {coinCount}";
        }
    }
}
