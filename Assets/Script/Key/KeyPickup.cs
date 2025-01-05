using UnityEngine;

public class KeyPickup : MonoBehaviour
{
    private KeyManager keyManager; // R�f�rence au KeyManager

    void Start()
    {
        // Trouver le KeyManager dans la sc�ne
        keyManager = FindObjectOfType<KeyManager>();
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Clef r�cup�r�e !");

            // Ajouter une cl� au KeyManager
            if (keyManager != null)
            {
                keyManager.AddKey();
            }

            // D�truire la cl� apr�s r�cup�ration
            Destroy(gameObject);
        }
    }
}
