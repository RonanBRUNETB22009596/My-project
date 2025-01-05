using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    public int damage = 20; // Dégâts infligés par le joueur
    public float attackRange = 2f; // Distance d'attaque
    public LayerMask enemyLayer; // Cible des attaques

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F)) // Touche pour attaquer
        {
            Attack();
        }
    }

    void Attack()
    {
        // Détecter les ennemis dans la portée d'attaque
        Collider[] hitEnemies = Physics.OverlapSphere(transform.position, attackRange, enemyLayer);

        foreach (Collider enemy in hitEnemies)
        {
            CoinEnemy coinEnemy = enemy.GetComponent<CoinEnemy>();
            if (coinEnemy != null)
            {
                coinEnemy.TakeDamage(damage);
                Debug.Log("L'ennemi a subi " + damage + " points de dégâts.");
            }
        }
    }

    void OnDrawGizmosSelected()
    {
        // Visualiser la portée d'attaque
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(transform.position, attackRange);
    }
}
