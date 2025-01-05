using UnityEngine;

public class InteractionSounds : MonoBehaviour
{
    public AudioSource audioSource; // R�f�rence � l'Audio Source
    public AudioClip coinPickupSound; // Son pour ramasser une pi�ce
    public AudioClip teleporter1Sound; // Son pour les t�l�porteurs bleus
    public AudioClip teleporter2Sound; // Son pour les t�l�porteurs oranges
    public AudioClip Key; // Son pour les clefs 
    public AudioClip Chest; // Son pour le coffre
    public AudioClip trophySound; // Son pour le troph�e

    void OnTriggerEnter(Collider other)
    {
        // V�rifier si c'est une pi�ce
        if (other.CompareTag("Coin"))
        {
            PlaySound(coinPickupSound);
            Destroy(other.gameObject); // D�truire la pi�ce apr�s collecte
        }
        // V�rifier si c'est un t�l�porteur bleu
        else if (other.CompareTag("Teleporter1"))
        {
            PlaySound(teleporter1Sound);
            // Ajoutez ici votre logique pour le t�l�porteur bleu
        }
        // V�rifier si c'est un t�l�porteur orange
        else if (other.CompareTag("Teleporter2"))
        {
            PlaySound(teleporter2Sound);
            // Ajoutez ici votre logique pour le t�l�porteur orange
        }
        else if (other.CompareTag("Key"))
        {
            PlaySound(Key);
            // Ajoutez ici votre logique pour le t�l�porteur orange
        }
        else if (other.CompareTag("Chest"))
        {
            PlaySound(Chest);
            // Ajoutez ici votre logique pour le t�l�porteur orange
        }
        // V�rifier si c'est un troph�e
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
            audioSource.PlayOneShot(clip); // Joue un son sp�cifique
        }
        else
        {
            Debug.LogError("AudioSource ou AudioClip manquant !");
        }
    }
}
