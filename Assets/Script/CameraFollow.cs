using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target; // L'objet à suivre (ton personnage)
    public Vector3 offset; // Décalage par rapport à la position du personnage

    void LateUpdate()
    {
        if (target != null)
        {
            transform.position = target.position + offset;
        }
    }
}
