using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    public float moveSpeed = 5f; // Vitesse de d�placement
    public float turnSpeed = 100f; // Vitesse de rotation continue
    public float jumpForce = 7f; // Force du saut

    // R�f�rences aux cam�ras
    public Camera MainCamera; // Cam�ra globale
    public Camera followCamera; // Cam�ra qui suit le personnage
    public Camera[] cameras; // Liste des cam�ras auxiliaires

    public DeathScreenController deathScreenController; // R�f�rence au script DeathMenuController
    private Rigidbody rb;
    private Animator animator;
    private bool isGrounded;
    private bool isDead;

    void Start()
    {
        // R�cup�ration du Rigidbody et de l'Animator
        rb = GetComponent<Rigidbody>();
        animator = GetComponent<Animator>();

        // Activer la cam�ra principale au d�part
        ActivateCamera(MainCamera);
    }

    void Update()
    {
        if (isDead) return ; // Bloquer les mouvements si le personnage est mort

        // D�placement avant/arri�re
        float move = Input.GetAxis("Vertical") * moveSpeed * Time.deltaTime;

        // Appliquer les d�placements
        transform.Translate(0, 0, move);

        // Rotation continue droite/gauche
        if (Input.GetKey(KeyCode.D))
        {
            transform.Rotate(0, turnSpeed * Time.deltaTime, 0);
        }
        else if (Input.GetKey(KeyCode.A))
        {
            transform.Rotate(0, -turnSpeed * Time.deltaTime, 0);
        }

        // Animation de marche
        if (Input.GetKey(KeyCode.Z) || Input.GetAxis("Vertical") > 0)
        {
            if (animator != null)
            {
                animator.SetBool("isWalking", true);
            }
        }
        else
        {
            if (animator != null)
            {
                animator.SetBool("isWalking", false);
            }
        }

        // Saut (touche P)
        if (Input.GetKeyDown(KeyCode.P) && isGrounded)
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);

            if (animator != null)
            {
                animator.SetTrigger("Jump");
            }
        }

        // Changer entre MainCamera et followCamera avec la touche "C"
        if (Input.GetKeyDown(KeyCode.C))
        {
            if (MainCamera != null && followCamera != null)
            {
                bool isOverviewActive = MainCamera.enabled;
                MainCamera.enabled = !isOverviewActive;
                followCamera.enabled = isOverviewActive;
            }
        }
  
    }

    void ActivateCamera(Camera activeCamera)
    {
        // D�sactiver toutes les cam�ras
        foreach (Camera cam in cameras)
        {
            if (cam != null) cam.enabled = false;
        }
        if (MainCamera != null) MainCamera.enabled = false;
        if (followCamera != null) followCamera.enabled = false;

        // Activer uniquement la cam�ra choisie
        if (activeCamera != null) activeCamera.enabled = true;
    }

    public void SwitchToCamera(Camera targetCamera)
    {
        ActivateCamera(targetCamera);
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }
        else if (collision.gameObject.CompareTag("Spike"))
        {
            Debug.Log("Spike collided!");
            Die();
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Spike"))
        {
            Debug.Log("Spike triggered!");
            Die();
        }
    }

    void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = false;
        }
    }

    void Die()
    {
        Debug.Log("Die() method called!");

        isDead = true;

        if (deathScreenController != null)
        {
            Debug.Log("Calling ShowDeathScreen()");
            deathScreenController.ShowDeathScreen(); // Affiche l'�cran de mort
        }
        else
        {
            Debug.LogError("DeathScreenController is not assigned in the Inspector!");
        }

        if (animator != null)
        {
            animator.SetTrigger("Die");
        }
    }
  

}
