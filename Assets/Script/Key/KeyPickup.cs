using UnityEngine;

public class KeyPickup : MonoBehaviour
{
    private KeyManager keyManager; // Référence au KeyManager

    void Start()
    {
        // Trouver le KeyManager dans la scène
        keyManager = FindObjectOfType<KeyManager>();
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Clef récupérée !");

            // Ajouter une clé au KeyManager
            if (keyManager != null)
            {
                keyManager.AddKey();
            }

            // Détruire la clé après récupération
            Destroy(gameObject);
        }
    }
}
