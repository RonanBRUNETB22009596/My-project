using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Reset : MonoBehaviour
{
    public Transform player;       // Le personnage � r�initialiser
    public Vector3 startPosition;  // Position de d�part du personnage
    public Quaternion startRotation; // Rotation initiale du personnage

    void Start()
    {
        // Initialise la position et la rotation de d�part avec la position actuelle du personnage
        if (player != null)
        {
            startPosition = player.position;
            startRotation = player.rotation;
        }
        else
        {
            Debug.LogError("Le champ 'Player' n'est pas assign� !");
        }
    }

    void Update()
    {
        // V�rifie si la touche R est press�e
        if (Input.GetKeyDown(KeyCode.R))
        {
            ResetLevel();
        }
    }

    public void ResetLevel()
    {
        if (player != null)
        {
            // R�initialise la position et la rotation du personnage
            player.position = startPosition;
            player.rotation = startRotation;

            // Log pour confirmer le reset
            Debug.Log("Niveau r�initialis� : Le personnage a �t� replac� � sa position de d�part.");
        }
        else
        {
            Debug.LogError("Impossible de r�initialiser le niveau : 'Player' n'est pas assign� !");
        }
    }
}