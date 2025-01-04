using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target; // L'objet � suivre (ton personnage)
    public Vector3 offset; // D�calage par rapport � la position du personnage

    void LateUpdate()
    {
        if (target != null)
        {
            transform.position = target.position + offset;
        }
    }
}
