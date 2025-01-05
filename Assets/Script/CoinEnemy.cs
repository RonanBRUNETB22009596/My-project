using UnityEngine;

public class CoinEnemy : MonoBehaviour
{
    public Transform player; // R�f�rence au joueur (drag & drop dans l'inspecteur)
    public float speed = 2f; // Vitesse de d�placement de l'ennemi
    public float detectionRange = 5f; // Distance � laquelle l'ennemi d�tecte le joueur
    public int damage = 10; // D�g�ts inflig�s au joueur
    public float attackInterval = 1.5f; // Temps entre deux attaques

    private float lastAttackTime; // Temps �coul� depuis la derni�re attaque
    private bool isChasing = false;

    void Update()
    {
        // Calculer la distance entre le joueur et l'ennemi
        float distanceToPlayer = Vector3.Distance(transform.position, player.position);

        // Si le joueur est dans la zone de d�tection
        if (distanceToPlayer <= detectionRange)
        {
            isChasing = true;
        }
        else
        {
            isChasing = false;
        }

        // Si l'ennemi poursuit le joueur
        if (isChasing)
        {
            ChasePlayer();

            // V�rifier si l'ennemi est suffisamment proche pour attaquer
            if (distanceToPlayer <= 1.5f) // Distance d'attaque
            {
                AttackPlayer();
            }
        }
    }

    void ChasePlayer()
    {
        // D�placer l'ennemi vers le joueur
        Vector3 direction = (player.position - transform.position).normalized;
        transform.position += direction * speed * Time.deltaTime;

        // Faire face au joueur
        transform.LookAt(new Vector3(player.position.x, transform.position.y, player.position.z));
    }

    void AttackPlayer()
    {
        // V�rifier si le d�lai d'attaque est respect�
        if (Time.time - lastAttackTime >= attackInterval)
        {
            lastAttackTime = Time.time;

            // Infliger des d�g�ts au joueur
            PlayerHealth playerHealth = player.GetComponent<PlayerHealth>();
            if (playerHealth != null)
            {
                playerHealth.TakeDamage(damage);
                Debug.Log("Le joueur a �t� attaqu� et a subi " + damage + " points de d�g�ts.");
            }
        }
    }

    void OnDrawGizmosSelected()
    {
        // Dessiner une sph�re pour repr�senter la port�e de d�tection dans l'�diteur
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, detectionRange);
    }
}
