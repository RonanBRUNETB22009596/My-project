using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public int maxHealth = 100; // Sant� maximale du joueur
    private int currentHealth; // Sant� actuelle
    public CharacterMovement characterMovement; // R�f�rence au script CharacterMovement
    public DeathScreenController deathScreenController; // R�f�rence au script DeathScreenController

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