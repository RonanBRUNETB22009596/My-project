using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class KeyManager : MonoBehaviour
{
    public Text keyText; // R�f�rence au texte dans le HUD
    private int keyCount = 0; // Nombre de cl�s collect�es

    void Start()
    {
        UpdateKeyText();
    }

    public void AddKey()
    {
        keyCount++; // Incr�menter le nombre de cl�s
        UpdateKeyText(); // Mettre � jour l'affichage dans le HUD
    }

    public int GetKeyCount()
    {
        return keyCount; // Retourner le nombre de cl�s collect�es
    }

    void UpdateKeyText()
    {
        keyText.text = "Clef : " + keyCount; // Mettre � jour le texte du HUD
    }
    public void UseKey()
    {
        if (keyCount > 0)
        {
            keyCount--; // R�duire le nombre de cl�s
            UpdateKeyText(); // Mettre � jour l'affichage dans le HUD
        }
        else
        {
            Debug.LogWarning("Aucune cl� � utiliser !");
        }
    }
}