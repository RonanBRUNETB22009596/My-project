using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    public int maxHealth = 100; // Santé maximale du joueur
    private int currentHealth; // Santé actuelle
    public Slider healthBar; // Référence à la barre de vie dans le HUD
    public CharacterMovement characterMovement; // Référence au script CharacterMovement
    public DeathScreenController deathScreenController; // Référence au script DeathScreenController

    void Start()
    {
        currentHealth = maxHealth;
        healthBar.maxValue = maxHealth; // Configurer la valeur maximale de la barre de vie
        healthBar.value = currentHealth; // Initialiser la barre de vie

        if (characterMovement == null)
        {
            characterMovement = GetComponent<CharacterMovement>();
        }
    }

    public void TakeDamage(int amount)
    {
        currentHealth -= amount;
        healthBar.value = currentHealth; // Mettre à jour la barre de vie
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