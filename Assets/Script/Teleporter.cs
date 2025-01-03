using UnityEngine;

public class Teleporter : MonoBehaviour
{
    public Transform targetTeleporter; // Le téléporteur de destination
    private bool isTeleporting = false; // Pour éviter les boucles de téléportation

    private void Start()
    {
        // Log des coordonnées de ce téléporteur
        Debug.Log($"[Teleporter] Initialisé à la position : {transform.position}");
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && !isTeleporting)
        {
            // Log avant la téléportation
            Debug.Log($"[Teleporter] Téléportation du joueur depuis {transform.position} vers {targetTeleporter.position}");

            // Déplace le joueur au téléporteur cible
            other.transform.position = targetTeleporter.position;

            // Active la protection contre les boucles de téléportation
            isTeleporting = true;

            // Log après la téléportation
            Debug.Log($"[Teleporter] Joueur téléporté avec succès à la position {targetTeleporter.position}");

            // Désactive temporairement la téléportation sur la cible
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
            Debug.Log($"[Teleporter] Joueur a quitté la zone du téléporteur à {transform.position}");

            // Permet de retéléporter une fois le joueur sorti
            isTeleporting = false;
        }
    }
}
