using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Chest : MonoBehaviour
{
    public GameObject key; // R�f�rence � la clef n�cessaire pour ouvrir le coffre
    public bool isOpened = false; // Indique si le coffre est ouvert
    public GameObject sword; // R�f�rence � l'�p�e que le joueur recevra
    public Transform swordHandPosition; // Position o� l'�p�e sera tenue dans la main du joueur
    public KeyManager keyManager; // R�f�rence au KeyManager pour v�rifier si le joueur a une clef
    public GameObject closedChestPrefab; // R�f�rence au prefab du coffre ferm�
    public GameObject openedChestPrefab; // R�f�rence au prefab du coffre ouvert

    void Update()
    {
        // V�rifier si le joueur appuie sur E pour ouvrir le coffre
        if (Input.GetKeyDown(KeyCode.E) && !isOpened)
        {
            TryOpenChest();
        }
    }

    void TryOpenChest()
    {
        if (keyManager != null && keyManager.GetKeyCount() > 0)
        {
            OpenChest();
            keyManager.UseKey(); // R�duire le nombre de clefs dans le KeyManager
        }
        else
        {
            Debug.Log("Vous avez besoin d'une clef pour ouvrir ce coffre.");
        }
    }

    void OpenChest()
    {
        Debug.Log("Coffre ouvert. Vous avez r�cup�r� l'�p�e !");
        isOpened = true;

        // Donner l'�p�e au joueur
        if (sword != null && swordHandPosition != null)
        {
            sword.SetActive(true);
            sword.transform.position = swordHandPosition.position;
            sword.transform.rotation = swordHandPosition.rotation;
            sword.transform.SetParent(swordHandPosition); // Faire de l'�p�e un enfant de la main du joueur
        }

        // Remplacer le coffre ferm� par le coffre ouvert
        if (openedChestPrefab != null)
        {
            GameObject openedChest = Instantiate(openedChestPrefab, transform.position, transform.rotation);
            Destroy(gameObject); // Supprimer le coffre ferm�
        }
    }
}
