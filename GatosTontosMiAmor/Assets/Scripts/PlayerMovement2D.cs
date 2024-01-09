using System.Collections;
using UnityEngine;

public class PlayerMovement2D : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private float jumpForce;

    [SerializeField] private Rigidbody2D rigidbody2D;

    [SerializeField] private Animator _animator;

    private float _horizontal;

    // private float _vertical;
    private bool _isFacingRight;

    [SerializeField] private Transform groundCheck;
    [SerializeField] private LayerMask groundLayer;

    private bool _isGrounded;
    private bool _isJumping;
    private bool _canJump;
    private bool _isFalling;
    private bool _isRising;
    private bool _isMoving;
    private bool _canMove = true;

    private static readonly int IsRising = Animator.StringToHash("isRising");
    private static readonly int IsMoving = Animator.StringToHash("isMoving");
    private static readonly int IsFalling = Animator.StringToHash("isFalling");
    private static readonly int Grounded = Animator.StringToHash("isGrounded");

    private void Start()
    {
        _isFacingRight = true;
    }

    private void Update()
    {
        if (!_canMove) return;

        _horizontal = Input.GetAxisRaw("Horizontal");
        // _vertical = Input.GetAxisRaw("Vertical");

        _isMoving = _horizontal != 0;
        _isGrounded = IsGrounded();
        _isJumping = Input.GetKeyDown(KeyCode.Space);
        _isRising = rigidbody2D.velocity.y > 0;
        _isFalling = rigidbody2D.velocity.y < 0;
        _canJump = _isGrounded && _isJumping;

        HandleDirectionSwitch();
        HandleJump();
        HandleFalling();
        HandleAnimation();
    }

    private IEnumerator DelayMovement()
    {
        _canMove = false;
        yield return new WaitForSeconds(0.375f);
        _canMove = true;
    }

    private void StartDelayMovement()
    {
        StartCoroutine(DelayMovement());
    }

    private void HandleAnimation()
    {
        _animator.SetBool(IsRising, _isRising);
        _animator.SetBool(IsFalling, _isFalling);
        _animator.SetBool(IsMoving, _isMoving);
    }

    private void HandleFalling()
    {
        if (_isFalling && Input.GetKey(KeyCode.S))
        {
            rigidbody2D.gravityScale = 5;
        }
        else
        {
            rigidbody2D.gravityScale = 2;
        }
    }

    private void HandleJump()
    {
        if (_canJump)
        {
            rigidbody2D.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
            _canJump = false;
        }
    }

    private void HandleDirectionSwitch()
    {
        if (_horizontal > 0 && !_isFacingRight)
        {
            Flip();
        }
        else if (_horizontal < 0 && _isFacingRight)
        {
            Flip();
        }

        if (_isGrounded)
        {
            rigidbody2D.velocity = new Vector2(_horizontal * speed, rigidbody2D.velocity.y);
        }
    }

    private void Flip()
    {
        _isFacingRight = !_isFacingRight;
        transform.Rotate(0f, 180f, 0f);
    }

    private bool IsGrounded()
    {
        var checkGround = Physics2D.Raycast(groundCheck.position, Vector2.down, 0.1f, groundLayer);

        _animator.SetBool(Grounded, checkGround);
        if (_isGrounded != checkGround)
        {
            StartCoroutine(DelayMovement());
        }

        return checkGround;
    }
}