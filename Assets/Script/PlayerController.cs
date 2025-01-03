using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Transform cameraTransform; // Transform de la cam�ra
    public float moveSpeed = 5.0f;    // Vitesse de d�placement
    public float turnSpeed = 10.0f;   // Vitesse de rotation

    private CharacterController characterController; // R�f�rence au CharacterController

    void Start()
    {
        // R�cup�re le CharacterController
        characterController = GetComponent<CharacterController>();
        if (cameraTransform == null)
        {
            Debug.LogError("La cam�ra n'est pas assign�e !");
        }
    }

    void Update()
    {
        // R�cup�re les entr�es de d�placement
        float horizontal = Input.GetAxis("Horizontal"); // A/D ou Q/D
        float vertical = Input.GetAxis("Vertical");     // W/S ou Z/S

        // Calcule la direction de d�placement par rapport � la cam�ra
        Vector3 forward = cameraTransform.forward;
        Vector3 right = cameraTransform.right;

        // Normalise les axes pour �viter les mouvements plus rapides en diagonale
        forward.y = 0; // On ignore l'axe vertical
        right.y = 0;
        forward.Normalize();
        right.Normalize();

        // Calcule la direction finale du mouvement
        Vector3 moveDirection = forward * vertical + right * horizontal;

        // D�place le personnage
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