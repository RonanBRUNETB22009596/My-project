using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    public float moveSpeed = 5f; // Vitesse de d�placement
    public float turnSpeed = 100f; // Vitesse de rotation continue
    public float jumpForce = 7f; // Force du saut

    public Camera MainCamera; // Cam�ra globale
    public Camera followCamera; // Cam�ra qui suit le personnage

    private Rigidbody rb;
    private Animator animator;
    private bool isGrounded;

    void Start()
    {
        // R�cup�ration du Rigidbody et de l'Animator
        rb = GetComponent<Rigidbody>();
        animator = GetComponent<Animator>();

        // Initialiser les cam�ras
        if (MainCamera != null && followCamera != null)
        {
            MainCamera.enabled = true;
            followCamera.enabled = false;
        }
    }

    void Update()
    {
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

        // Saut (touche Espace)
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            // Ajouter une force vers le haut pour sauter
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);

            // Jouer l'animation de saut
            if (animator != null)
            {
                animator.SetTrigger("Jump");
            }
        }

        // Changer de cam�ra avec la touche "C"
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

    void OnCollisionEnter(Collision collision)
    {
        // V�rifier si le personnage est au sol
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }
    }

    void OnCollisionExit(Collision collision)
    {
        // V�rifier si le personnage n'est plus au sol
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = false;
        }
    }
}
