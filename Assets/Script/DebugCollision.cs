using UnityEngine;

public class DebugCollision : MonoBehaviour
{
    void OnCollisionEnter(Collision collision)
    {
        Debug.Log("Collision d�tect�e avec : " + collision.gameObject.name);
    }
}
