using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraZone : MonoBehaviour
{
    public Camera targetCamera; // Caméra à activer dans cette zone

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) // Vérifie si le joueur entre dans la zone
        {
            CharacterMovement player = other.GetComponent<CharacterMovement>();
            if (player != null)
            {
                player.SwitchToCamera(targetCamera);
            }
        }
    }
}