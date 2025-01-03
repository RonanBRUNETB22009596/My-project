using UnityEngine;

public class CylinderMovement : MonoBehaviour
{
    public float speed = 5f; // Vitesse de déplacement
    public Transform teleporter1; // Position du premier téléporteur
    public Transform teleporter2; // Position du second téléporteur

    private bool isTeleporting = false; // Pour éviter les boucles de téléportation

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
    //        Debug.Log($"Entrée dans Teleporter1. Coordonnées actuelles : ({transform.position.x}, {transform.position.y}, {transform.position.z})");
    //        TeleportTo(teleporter2.position, "Teleporter1", "Teleporter2");
    //    }
    //    else if (other.CompareTag("Teleporter2") && !isTeleporting)
    //    {
    //        Debug.Log($"Entrée dans Teleporter2. Coordonnées actuelles : ({transform.position.x}, {transform.position.y}, {transform.position.z})");
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

    //    Debug.Log($"Téléportation depuis {from} vers {to}.");
    //    Debug.Log($"Position avant téléportation : ({transform.position.x}, {transform.position.y}, {transform.position.z})");

   

    //    Debug.Log($"Position cible ajustée : ({targetPosition.x}, {targetPosition.y}, {targetPosition.z})");

    //    // Appliquer la position ajustée
    //    transform.position = targetPosition;

    //    Debug.Log($"Position après téléportation : ({transform.position.x}, {transform.position.y}, {transform.position.z})");

    //    Invoke("ResetTeleport", 0.5f);
    //}

    //private void ResetTeleport()
    //{
    //    isTeleporting = false;
    //}
}
