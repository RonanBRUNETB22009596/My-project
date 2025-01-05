using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public int maxHealth = 100; // Sant� maximale du joueur
    private int currentHealth; // Sant� actuelle

    void Start()
    {
        currentHealth = maxHealth;
    }

    public void TakeDamage(int amount)
    {
        currentHealth -= amount;
        Debug.Log("Sant� du joueur : " + currentHealth);

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        Debug.Log("Le joueur est mort !");
        // Ajouter des actions suppl�mentaires comme recharger la sc�ne
    }
}