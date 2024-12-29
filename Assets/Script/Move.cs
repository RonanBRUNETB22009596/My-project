using UnityEngine;

public class Move : MonoBehaviour
{
    public float vitesse = 5f; // Vitesse de déplacement

    void Update()
    {
        // Récupération des entrées clavier (ZQSD)
        float mouvementHorizontal = 0f;
        float mouvementVertical = 0f;

        if (Input.GetKey(KeyCode.Z)) // Avancer (Z)
        {
            mouvementVertical = 1f;
        }
        if (Input.GetKey(KeyCode.S)) // Reculer (S)
        {
            mouvementVertical = -1f;
        }
        if (Input.GetKey(KeyCode.Q)) // Aller à gauche (Q)
        {
            mouvementHorizontal = -1f;
        }
        if (Input.GetKey(KeyCode.D)) // Aller à droite (D)
        {
            mouvementHorizontal = 1f;
        }

        // Calcul du déplacement
        Vector3 mouvement = new Vector3(mouvementHorizontal, 0f, mouvementVertical).normalized;

        // Appliquer le déplacement
        transform.Translate(mouvement * vitesse * Time.deltaTime, Space.World);
    }
}
