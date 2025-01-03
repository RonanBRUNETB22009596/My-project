using UnityEngine;

public class Teleporter : MonoBehaviour
{
    public Transform targetTeleporter; // Le t�l�porteur de destination
    private bool isTeleporting = false; // Pour �viter les boucles de t�l�portation

    private void Start()
    {
        // Log des coordonn�es de ce t�l�porteur
        Debug.Log($"[Teleporter] Initialis� � la position : {transform.position}");
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && !isTeleporting)
        {
            // Log avant la t�l�portation
            Debug.Log($"[Teleporter] T�l�portation du joueur depuis {transform.position} vers {targetTeleporter.position}");

            // D�place le joueur au t�l�porteur cible
            other.transform.position = targetTeleporter.position;

            // Active la protection contre les boucles de t�l�portation
            isTeleporting = true;

            // Log apr�s la t�l�portation
            Debug.Log($"[Teleporter] Joueur t�l�port� avec succ�s � la position {targetTeleporter.position}");

            // D�sactive temporairement la t�l�portation sur la cible
            Teleporter targetScript = targetTeleporter.GetComponent<Teleporter>();
            if (targetScript != null)
            {
                targetScript.isTeleporting = true;
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            // Log lorsque le joueur quitte la zone de collision
            Debug.Log($"[Teleporter] Joueur a quitt� la zone du t�l�porteur � {transform.position}");

            // Permet de ret�l�porter une fois le joueur sorti
            isTeleporting = false;
        }
    }
}
