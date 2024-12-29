using UnityEngine;

public class Move : MonoBehaviour
{
    public float vitesse = 5f; // Vitesse de d�placement

    void Update()
    {
        // R�cup�ration des entr�es clavier (ZQSD)
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
        if (Input.GetKey(KeyCode.Q)) // Aller � gauche (Q)
        {
            mouvementHorizontal = -1f;
        }
        if (Input.GetKey(KeyCode.D)) // Aller � droite (D)
        {
            mouvementHorizontal = 1f;
        }

        // Calcul du d�placement
        Vector3 mouvement = new Vector3(mouvementHorizontal, 0f, mouvementVertical).normalized;

        // Appliquer le d�placement
        transform.Translate(mouvement * vitesse * Time.deltaTime, Space.World);
    }
}
