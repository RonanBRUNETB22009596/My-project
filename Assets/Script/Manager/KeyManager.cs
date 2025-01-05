using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class KeyManager : MonoBehaviour
{
    public Text keyText; // Référence au texte dans le HUD
    private int keyCount = 0; // Nombre de clés collectées

    void Start()
    {
        UpdateKeyText();
    }

    public void AddKey()
    {
        keyCount++; // Incrémenter le nombre de clés
        UpdateKeyText(); // Mettre à jour l'affichage dans le HUD
    }

    public int GetKeyCount()
    {
        return keyCount; // Retourner le nombre de clés collectées
    }

    void UpdateKeyText()
    {
        keyText.text = "Clef : " + keyCount; // Mettre à jour le texte du HUD
    }
    public void UseKey()
    {
        if (keyCount > 0)
        {
            keyCount--; // Réduire le nombre de clés
            UpdateKeyText(); // Mettre à jour l'affichage dans le HUD
        }
        else
        {
            Debug.LogWarning("Aucune clé à utiliser !");
        }
    }
}