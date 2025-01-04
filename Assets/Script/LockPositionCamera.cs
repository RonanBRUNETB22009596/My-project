using UnityEngine;

public class LockPositionCamera : MonoBehaviour
{
    private Vector3 initialPosition;

    void Start()
    {
        // Stocke la position initiale de la cam�ra
        initialPosition = transform.position;
    }

    void Update()
    {
        // Verrouille la cam�ra � sa position initiale
        transform.position = initialPosition;
    }
}
