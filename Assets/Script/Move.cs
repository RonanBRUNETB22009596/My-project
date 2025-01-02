using UnityEngine;

public class CylinderMovement : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 5f; // Movement speed
    [SerializeField] private float jumpForce = 5f; // Jump force
    [SerializeField] private LayerMask groundLayer; // Layer to check for ground

    private Rigidbody rb;
    private bool isGrounded;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        // Check if the cylinder is on the ground
        isGrounded = Physics.Raycast(transform.position, Vector3.down, 1.1f, groundLayer);

        // Handle movement
        float moveX = Input.GetKey(KeyCode.Q) ? -1 : Input.GetKey(KeyCode.D) ? 1 : 0;
        float moveZ = Input.GetKey(KeyCode.Z) ? 1 : Input.GetKey(KeyCode.S) ? -1 : 0;
        Vector3 movement = new Vector3(moveX, 0, moveZ).normalized * moveSpeed;

        // Apply movement
        rb.velocity = new Vector3(movement.x, rb.velocity.y, movement.z);

        // Handle jump
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        }
    }
}
