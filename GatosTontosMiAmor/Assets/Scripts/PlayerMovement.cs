using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float jumpForce = 10f;
    public Transform groundCheck;
    public LayerMask groundLayer;
    public float groundCheckRadius = 0.1f;
    public bool debug = false;

    private Rigidbody2D _rb;
    private bool _isGrounded;

    private void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        // Check if the player is grounded.
        _isGrounded = Physics2D.Raycast(groundCheck.position, Vector2.down, groundCheckRadius, groundLayer);

        if (debug)
        {
            Debug.DrawRay(groundCheck.position, Vector2.down * groundCheckRadius, Color.red);
        }
            // Handle player input for movement.
            float moveInput = Input.GetAxis("Horizontal");
        Vector2 moveVelocity = new Vector2(moveInput * moveSpeed, _rb.velocity.y);
        _rb.velocity = moveVelocity;

        // Handle jumping.
        if (_isGrounded && Input.GetButtonDown("Jump"))
        {
            _rb.velocity = new Vector2(_rb.velocity.x, jumpForce);
        }
    }
}