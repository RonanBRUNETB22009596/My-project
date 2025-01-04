using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) // V�rifie si le joueur entre en collision avec la pi�ce
        {
            // Ajoute la pi�ce au compteur
            CoinManager.Instance.AddCoin();

            // D�truit la pi�ce
            Destroy(gameObject);
        }
    }
}
