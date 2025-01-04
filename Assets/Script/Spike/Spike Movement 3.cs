using UnityEngine;

public class SpikeMovement3 : MonoBehaviour
{
    [SerializeField] private float speed = 5f; // Movement speed
    [SerializeField] private float maxZ = -3f;  // Maximum Z position
    [SerializeField] private float minZ = -8f; // Minimum Z position

    private bool movingForward = true; // Direction flag

    void Update()
    {
        float step = speed * Time.deltaTime;

        if (movingForward)
        {
            transform.position += new Vector3(0, 0, step);

            if (transform.position.z >= maxZ)
            {
                movingForward = false;
            }
        }
        else
        {
            transform.position -= new Vector3(0, 0, step);

            if (transform.position.z <= minZ)
            {
                movingForward = true;
            }
        }
    }
}
