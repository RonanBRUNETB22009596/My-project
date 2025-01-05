using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Chest : MonoBehaviour
{
    public GameObject key; // Référence à la clef nécessaire pour ouvrir le coffre
    public bool isOpened = false; // Indique si le coffre est ouvert
    public GameObject sword; // Référence à l'épée que le joueur recevra
    public Transform swordHandPosition; // Position où l'épée sera tenue dans la main du joueur
    public KeyManager keyManager; // Référence au KeyManager pour vérifier si le joueur a une clef
    public GameObject closedChestPrefab; // Référence au prefab du coffre fermé
    public GameObject openedChestPrefab; // Référence au prefab du coffre ouvert

    void Update()
    {
        // Vérifier si le joueur appuie sur E pour ouvrir le coffre
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
            keyManager.UseKey(); // Réduire le nombre de clefs dans le KeyManager
        }
        else
        {
            Debug.Log("Vous avez besoin d'une clef pour ouvrir ce coffre.");
        }
    }

    void OpenChest()
    {
        Debug.Log("Coffre ouvert. Vous avez récupéré l'épée !");
        isOpened = true;

        // Donner l'épée au joueur
        if (sword != null && swordHandPosition != null)
        {
            sword.SetActive(true);
            sword.transform.position = swordHandPosition.position;
            sword.transform.rotation = swordHandPosition.rotation;
            sword.transform.SetParent(swordHandPosition); // Faire de l'épée un enfant de la main du joueur
        }

        // Remplacer le coffre fermé par le coffre ouvert
        if (openedChestPrefab != null)
        {
            GameObject openedChest = Instantiate(openedChestPrefab, transform.position, transform.rotation);
            Destroy(gameObject); // Supprimer le coffre fermé
        }
    }
}
