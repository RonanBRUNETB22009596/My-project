using UnityEngine;

public class CylinderMovement : MonoBehaviour
{
    public float speed = 5f; // Vitesse de d�placement
    public Transform teleporter1; // Position du premier t�l�porteur
    public Transform teleporter2; // Position du second t�l�porteur

    private bool isTeleporting = false; // Pour �viter les boucles de t�l�portation

    void Update()
    {
        // Gestion du mouvement
        float moveHorizontal = Input.GetKey(KeyCode.Q) ? -1f : Input.GetKey(KeyCode.D) ? 1f : 0f;
        float moveVertical = Input.GetKey(KeyCode.Z) ? 1f : Input.GetKey(KeyCode.S) ? -1f : 0f;

        Vector3 movement = new Vector3(moveHorizontal, 0f, moveVertical).normalized;
        transform.Translate(movement * speed * Time.deltaTime, Space.World);
    }

    //private void OnTriggerEnter(Collider other)
    //{
    //    if (other.CompareTag("Teleporter1") && !isTeleporting)
    //    {
    //        Debug.Log($"Entr�e dans Teleporter1. Coordonn�es actuelles : ({transform.position.x}, {transform.position.y}, {transform.position.z})");
    //        TeleportTo(teleporter2.position, "Teleporter1", "Teleporter2");
    //    }
    //    else if (other.CompareTag("Teleporter2") && !isTeleporting)
    //    {
    //        Debug.Log($"Entr�e dans Teleporter2. Coordonn�es actuelles : ({transform.position.x}, {transform.position.y}, {transform.position.z})");
    //        TeleportTo(teleporter1.position, "Teleporter2", "Teleporter1");
    //    }
    //    else
    //    {
    //        Debug.Log($"Collision avec un objet inattendu : {other.name} (Tag : {other.tag})");
    //    }
    //}

    //private void TeleportTo(Vector3 targetPosition, string from, string to)
    //{
    //    isTeleporting = true;

    //    Debug.Log($"T�l�portation depuis {from} vers {to}.");
    //    Debug.Log($"Position avant t�l�portation : ({transform.position.x}, {transform.position.y}, {transform.position.z})");

   

    //    Debug.Log($"Position cible ajust�e : ({targetPosition.x}, {targetPosition.y}, {targetPosition.z})");

    //    // Appliquer la position ajust�e
    //    transform.position = targetPosition;

    //    Debug.Log($"Position apr�s t�l�portation : ({transform.position.x}, {transform.position.y}, {transform.position.z})");

    //    Invoke("ResetTeleport", 0.5f);
    //}

    //private void ResetTeleport()
    //{
    //    isTeleporting = false;
    //}
}
