using UnityEngine;

public class LockPositionCamera : MonoBehaviour
{
    private Vector3 initialPosition;

    void Start()
    {
        // Stocke la position initiale de la caméra
        initialPosition = transform.position;
    }

    void Update()
    {
        // Verrouille la caméra à sa position initiale
        transform.position = initialPosition;
    }
}
