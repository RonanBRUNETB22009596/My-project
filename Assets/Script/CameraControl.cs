using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour
{
    public Transform target;        // L'objet que la cam�ra suit (le personnage)
    public float sensitivity = 3.0f; // Sensibilit� de la souris
    public float distance = 5.0f;   // Distance entre la cam�ra et le personnage
    public float height = 2.0f;     // Hauteur de la cam�ra par rapport au personnage
    public float rotationSpeed = 5.0f; // Vitesse de rotation (optionnel pour lissage)

    private float rotationY = 0.0f; // Rotation autour de l'axe Y
    private float rotationX = 0.0f; // Rotation autour de l'axe X

    void Start()
    {
        // Initialiser les angles de rotation en fonction de la position actuelle de la cam�ra
        Vector3 angles = transform.eulerAngles;
        rotationY = angles.y;
        rotationX = angles.x;
    }

    void LateUpdate()
    {
        if (target == null)
        {
            Debug.LogWarning("Le champ 'Target' n'est pas d�fini !");
            return;
        }

        // Si le clic droit est enfonc�
        if (Input.GetMouseButton(1))
        {
            // R�cup�re les mouvements de la souris
            float mouseX = Input.GetAxis("Mouse X") * sensitivity;
            float mouseY = Input.GetAxis("Mouse Y") * sensitivity;

            // Met � jour les rotations
            rotationY += mouseX;
            rotationX -= mouseY;
            rotationX = Mathf.Clamp(rotationX, -45f, 45f); // Limite la rotation verticale
        }

        // Calcule la position et la rotation de la cam�ra
        Quaternion rotation = Quaternion.Euler(rotationX, rotationY, 0);
        Vector3 position = target.position - (rotation * Vector3.forward * distance) + (Vector3.up * height);

        // Applique la rotation et la position
        transform.position = Vector3.Lerp(transform.position, position, Time.deltaTime * rotationSpeed);
        transform.LookAt(target); // Oriente la cam�ra vers la cible
    }
}