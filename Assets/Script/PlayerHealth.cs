using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    public int maxHealth = 100; // Sant� maximale du joueur
    private int currentHealth; // Sant� actuelle
    public Slider healthBar; // R�f�rence � la barre de vie dans le HUD
    public CharacterMovement characterMovement; // R�f�rence au script CharacterMovement
    public DeathScreenController deathScreenController; // R�f�rence au script DeathScreenController

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
        healthBar.value = currentHealth; // Mettre � jour la barre de vie
        Debug.Log("Sant� du joueur : " + currentHealth);

        if (currentHealth <= 0)
        {
            Die();
        }
    }


    void Die()
    {
        Debug.Log("Le joueur est mort !");

        // D�sactiver les mouvements
        if (characterMovement != null)
        {
            characterMovement.enabled = false;
        }

        // Afficher l'�cran de mort
        if (deathScreenController != null)
        {
            deathScreenController.ShowDeathScreen();
        }
        else
        {
            Debug.LogError("DeathScreenController n'est pas assign� dans l'inspecteur !");
        }
    }
}