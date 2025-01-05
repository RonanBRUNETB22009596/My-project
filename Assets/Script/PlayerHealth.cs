using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public int maxHealth = 100; // Santé maximale du joueur
    private int currentHealth; // Santé actuelle
    public CharacterMovement characterMovement; // Référence au script CharacterMovement
    public DeathScreenController deathScreenController; // Référence au script DeathScreenController

    void Start()
    {
        currentHealth = maxHealth;

        if (characterMovement == null)
        {
            characterMovement = GetComponent<CharacterMovement>();
        }
    }

    public void TakeDamage(int amount)
    {
        currentHealth -= amount;
        Debug.Log("Santé du joueur : " + currentHealth);

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        Debug.Log("Le joueur est mort !");

        // Désactiver les mouvements
        if (characterMovement != null)
        {
            characterMovement.enabled = false;
        }

        // Afficher l'écran de mort
        if (deathScreenController != null)
        {
            deathScreenController.ShowDeathScreen();
        }
        else
        {
            Debug.LogError("DeathScreenController n'est pas assigné dans l'inspecteur !");
        }
    }
}