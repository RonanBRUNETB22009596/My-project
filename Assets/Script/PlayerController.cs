using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Transform cameraTransform; // Transform de la caméra
    public float moveSpeed = 5.0f;    // Vitesse de déplacement
    public float turnSpeed = 10.0f;   // Vitesse de rotation

    private CharacterController characterController; // Référence au CharacterController

    void Start()
    {
        // Récupère le CharacterController
        characterController = GetComponent<CharacterController>();
        if (cameraTransform == null)
        {
            Debug.LogError("La caméra n'est pas assignée !");
        }
    }

    void Update()
    {
        // Récupère les entrées de déplacement
        float horizontal = Input.GetAxis("Horizontal"); // A/D ou Q/D
        float vertical = Input.GetAxis("Vertical");     // W/S ou Z/S

        // Calcule la direction de déplacement par rapport à la caméra
        Vector3 forward = cameraTransform.forward;
        Vector3 right = cameraTransform.right;

        // Normalise les axes pour éviter les mouvements plus rapides en diagonale
        forward.y = 0; // On ignore l'axe vertical
        right.y = 0;
        forward.Normalize();
        right.Normalize();

        // Calcule la direction finale du mouvement
        Vector3 moveDirection = forward * vertical + right * horizontal;

        // Déplace le personnage
        if (moveDirection.magnitude >= 0.1f)
        {
            // Tourne le personnage vers la direction du mouvement
            Quaternion targetRotation = Quaternion.LookRotation(moveDirection);
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, turnSpeed * Time.deltaTime);

            // Applique le mouvement
            characterController.Move(moveDirection * moveSpeed * Time.deltaTime);
        }
    }
}