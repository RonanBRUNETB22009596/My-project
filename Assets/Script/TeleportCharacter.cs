using UnityEngine;

public class TeleportByTouch : MonoBehaviour
{
    [SerializeField] private GameObject teleportOrange; // Reference to the orange teleporter

    private void OnTriggerEnter(Collider other)
    {
        // Check if the object entering the trigger is the player
        if (other.CompareTag("Player"))
        {
            // Teleport the player to the position of the orange teleporter
            other.transform.position = teleportOrange.transform.position;
        }
    }
}
