using UnityEngine;

public class InteractionSounds : MonoBehaviour
{
    public AudioSource audioSource; // Référence à l'Audio Source
    public AudioClip coinPickupSound; // Son pour ramasser une pièce
    public AudioClip teleporter1Sound; // Son pour les téléporteurs bleus
    public AudioClip teleporter2Sound; // Son pour les téléporteurs oranges
    public AudioClip Key; // Son pour les clefs 
    public AudioClip Chest; // Son pour le coffre
    public AudioClip trophySound; // Son pour le trophée

    void OnTriggerEnter(Collider other)
    {
        // Vérifier si c'est une pièce
        if (other.CompareTag("Coin"))
        {
            PlaySound(coinPickupSound);
            Destroy(other.gameObject); // Détruire la pièce après collecte
        }
        // Vérifier si c'est un téléporteur bleu
        else if (other.CompareTag("Teleporter1"))
        {
            PlaySound(teleporter1Sound);
            // Ajoutez ici votre logique pour le téléporteur bleu
        }
        // Vérifier si c'est un téléporteur orange
        else if (other.CompareTag("Teleporter2"))
        {
            PlaySound(teleporter2Sound);
            // Ajoutez ici votre logique pour le téléporteur orange
        }
        else if (other.CompareTag("Key"))
        {
            PlaySound(Key);
            // Ajoutez ici votre logique pour le téléporteur orange
        }
        else if (other.CompareTag("Chest"))
        {
            PlaySound(Chest);
            // Ajoutez ici votre logique pour le téléporteur orange
        }
        // Vérifier si c'est un trophée
        else if (other.CompareTag("Trophy"))
        {
            PlaySound(trophySound);
            // Ajoutez ici votre logique de victoire
        }
    }

    void PlaySound(AudioClip clip)
    {
        if (audioSource != null && clip != null)
        {
            audioSource.PlayOneShot(clip); // Joue un son spécifique
        }
        else
        {
            Debug.LogError("AudioSource ou AudioClip manquant !");
        }
    }
}
