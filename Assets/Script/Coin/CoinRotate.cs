using UnityEngine;

public class CoinRotate : MonoBehaviour
{
    [SerializeField] private float rotationSpeed = 100f; // Speed of rotation in degrees per second

    void Update()
    {
        // Rotate the coin around the local Y-axis, respecting its initial X rotation
        transform.Rotate(0, rotationSpeed * Time.deltaTime, 0, Space.World);
    }
}
