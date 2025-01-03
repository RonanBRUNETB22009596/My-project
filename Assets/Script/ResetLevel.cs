using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Reset : MonoBehaviour
{
    public Transform player;       // Le personnage à réinitialiser
    public Vector3 startPosition;  // Position de départ du personnage
    public Quaternion startRotation; // Rotation initiale du personnage

    void Start()
    {
        // Initialise la position et la rotation de départ avec la position actuelle du personnage
        if (player != null)
        {
            startPosition = player.position;
            startRotation = player.rotation;
        }
        else
        {
            Debug.LogError("Le champ 'Player' n'est pas assigné !");
        }
    }

    void Update()
    {
        // Vérifie si la touche R est pressée
        if (Input.GetKeyDown(KeyCode.R))
        {
            ResetLevel();
        }
    }

    public void ResetLevel()
    {
        if (player != null)
        {
            // Réinitialise la position et la rotation du personnage
            player.position = startPosition;
            player.rotation = startRotation;

            // Log pour confirmer le reset
            Debug.Log("Niveau réinitialisé : Le personnage a été replacé à sa position de départ.");
        }
        else
        {
            Debug.LogError("Impossible de réinitialiser le niveau : 'Player' n'est pas assigné !");
        }
    }
}