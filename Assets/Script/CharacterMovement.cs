using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    public float moveSpeed = 5f; // Vitesse de déplacement
    public float turnSpeed = 100f; // Vitesse de rotation continue
    public float jumpForce = 7f; // Force du saut

    // Références aux caméras
    public Camera MainCamera; // Caméra globale
    public Camera followCamera; // Caméra qui suit le personnage
    public Camera[] cameras; // Liste des caméras auxiliaires

    private Rigidbody rb;
    private Animator animator;
    private bool isGrounded;

    void Start()
    {
        // Récupération du Rigidbody et de l'Animator
        rb = GetComponent<Rigidbody>();
        animator = GetComponent<Animator>();

        // Activer la caméra principale au départ
        ActivateCamera(MainCamera);
    }

    void Update()
    {
        // Déplacement avant/arrière
        float move = Input.GetAxis("Vertical") * moveSpeed * Time.deltaTime;

        // Appliquer les déplacements
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
        // Désactiver toutes les caméras
        foreach (Camera cam in cameras)
        {
            if (cam != null) cam.enabled = false;
        }
        if (MainCamera != null) MainCamera.enabled = false;
        if (followCamera != null) followCamera.enabled = false;

        // Activer uniquement la caméra choisie
        if (activeCamera != null) activeCamera.enabled = true;
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }
    }

    void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = false;
        }
    }

    public void SwitchToCamera(Camera targetCamera)
    {
        ActivateCamera(targetCamera);
    }
}