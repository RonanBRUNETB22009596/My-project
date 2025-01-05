using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CoinManager : MonoBehaviour
{
    public static CoinManager Instance; // Instance pour un acc�s global
    public Text coinText;               // R�f�rence au texte UI pour le compteur

    private int coinCount = 0;          // Compteur des pi�ces

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

    // M�thode pour ajouter une pi�ce
    public void AddCoin()
    {
        coinCount++;
        UpdateUI();
    }

    // Met � jour le texte UI
    private void UpdateUI()
    {
        if (coinText != null)
        {
            coinText.text = $"Pi�ces : {coinCount}";
        }
    }
}
