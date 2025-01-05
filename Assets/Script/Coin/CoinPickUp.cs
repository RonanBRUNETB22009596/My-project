using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) // Vérifie si le joueur entre en collision avec la pièce
        {
            // Ajoute la pièce au compteur
            CoinManager.Instance.AddCoin();

            // Détruit la pièce
            Destroy(gameObject);
        }
    }
}
