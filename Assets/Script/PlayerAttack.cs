using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    public int damage = 20; // D�g�ts inflig�s par le joueur
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
        // D�tecter les ennemis dans la port�e d'attaque
        Collider[] hitEnemies = Physics.OverlapSphere(transform.position, attackRange, enemyLayer);

        foreach (Collider enemy in hitEnemies)
        {
            CoinEnemy coinEnemy = enemy.GetComponent<CoinEnemy>();
            if (coinEnemy != null)
            {
                coinEnemy.TakeDamage(damage);
                Debug.Log("L'ennemi a subi " + damage + " points de d�g�ts.");
            }
        }
    }

    void OnDrawGizmosSelected()
    {
        // Visualiser la port�e d'attaque
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(transform.position, attackRange);
    }
}
