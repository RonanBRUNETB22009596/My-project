using UnityEngine;

public class CoinEnemy : MonoBehaviour
{
    public Transform player; // Référence au joueur (drag & drop dans l'inspecteur)
    public float speed = 2f; // Vitesse de déplacement de l'ennemi
    public float detectionRange = 5f; // Distance à laquelle l'ennemi détecte le joueur
    public int damage = 10; // Dégâts infligés au joueur
    public float attackInterval = 1.5f; // Temps entre deux attaques
    public int maxHealth = 50; // Santé maximale de l'ennemi

    private int currentHealth;
    private float lastAttackTime; // Temps écoulé depuis la dernière attaque
    private bool isChasing = false;

    void Start()
    {
        currentHealth = maxHealth;
    }

    void Update()
    {
        // Calculer la distance entre le joueur et l'ennemi
        float distanceToPlayer = Vector3.Distance(transform.position, player.position);

        // Si le joueur est dans la zone de détection
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

            // Vérifier si l'ennemi est suffisamment proche pour attaquer
            if (distanceToPlayer <= 1.5f) // Distance d'attaque
            {
                AttackPlayer();
            }
        }
    }

    void ChasePlayer()
    {
        // Déplacer l'ennemi vers le joueur
        Vector3 direction = (player.position - transform.position).normalized;
        transform.position += direction * speed * Time.deltaTime;

        // Faire face au joueur
        transform.LookAt(new Vector3(player.position.x, transform.position.y, player.position.z));
    }

    void AttackPlayer()
    {
        // Vérifier si le délai d'attaque est respecté
        if (Time.time - lastAttackTime >= attackInterval)
        {
            lastAttackTime = Time.time;

            // Infliger des dégâts au joueur
            PlayerHealth playerHealth = player.GetComponent<PlayerHealth>();
            if (playerHealth != null)
            {
                playerHealth.TakeDamage(damage);
                Debug.Log("Le joueur a été attaqué et a subi " + damage + " points de dégâts.");
            }
        }
    }

    public void TakeDamage(int amount)
    {
        currentHealth -= amount;
        Debug.Log("Santé de l'ennemi : " + currentHealth);

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        Debug.Log("L'ennemi est mort !");
        Destroy(gameObject); // Supprime l'objet de la scène
    }

    void OnDrawGizmosSelected()
    {
        // Dessiner une sphère pour représenter la portée de détection dans l'éditeur
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, detectionRange);
    }
}
