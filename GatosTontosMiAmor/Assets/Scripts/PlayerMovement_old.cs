using System;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Serialization;

public class PlayerMovement : MonoBehaviour
{
    public float baseMoveSpeed = 5f;
    public float runSpeed = 10f;
    public float jumpForce = 10f;
    public float fastFallMultiplier = 2.5f;
    public float coyoteTime = 0.1f;
    public float speedBoostPerSecond = 0.1f;
    public float runSpeedBuffDuration = 2f; // Duration of the run speed buff
    
    [SerializeField] private Animator animator;
    [SerializeField] private Transform groundCheckTransform;

    public bool IsJumping { get; private set; }
    public bool IsRunning { get; private set; }
    public bool IsWalking { get; private set; }
    public bool IsIdle { get; private set; }

    private Rigidbody2D _rb;
    private bool _isGrounded;
    private float _coyoteTimer;
    private float _originalGravity;
    private float _speedBuffTimer;
    private bool _isMoving;
    
    private int animHashWalking;
    private int groundLayerMask = 3;
    
    private void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        _originalGravity = _rb.gravityScale;
        ResetSpeedBuffTimer();
    }

    private void Awake()
    {
        animHashWalking = Animator.StringToHash("IsWalking");
    }

    private void Update()
    {
        HandleMovementInput();
        HandleJumping();
        HandleFastFalling();
        HandleCoyoteTime();
        HandleSpeedBoost();
        UpdateAnimationStates();

        // Other updates as needed...
    }

    private void HandleMovementInput()
    {
        float moveInput = Input.GetAxis("Horizontal");

        if (Mathf.Abs(moveInput) > 0.01f)
        {
            _isMoving = true;
            ResetSpeedBuffTimer();

            // Change direction instantly by setting velocity to the desired speed
            float currentMoveSpeed = _isMoving ? runSpeed : baseMoveSpeed;
            _rb.velocity = new Vector2(moveInput * currentMoveSpeed, _rb.velocity.y);
        }
        else
        {
            _isMoving = false;
            DecreaseSpeedBuffTimer();
        }
    }


    private void HandleJumping()
    {
        _isGrounded = Physics2D.Raycast(groundCheckTransform.position, Vector2.down, 0.1f);
        // Debug.Log(_isGrounded);
        if (Input.GetButtonDown("Jump") && (_isGrounded || _coyoteTimer > 0))
        {
            Jump();
        }
    }

    private void HandleFastFalling()
    {
        if (Input.GetButton("Jump") && _rb.velocity.y < 0)
        {
            _rb.gravityScale = _originalGravity * fastFallMultiplier;
        }
        else
        {
            _rb.gravityScale = _originalGravity;
        }
    }

    private void HandleCoyoteTime()
    {
    _coyoteTimer = _isGrounded ? coyoteTime : Mathf.Max(_coyoteTimer - Time.deltaTime, 0);
    }
    
    // private void HandleCoyoteTime()
    // {
    //     // // Use LayerMask to filter collisions only with objects on the "Ground" layer
    //     // int groundLayerMask = 1 << LayerMask.NameToLayer("Ground");
    //     // _isGrounded = Physics2D.Raycast(groundCheckTransform.position, Vector2.down, 0.1f, groundLayerMask) != null;
    //     //
    //     // _coyoteTimer = _isGrounded ? coyoteTime : Mathf.Max(_coyoteTimer - Time.deltaTime, 0);
    // }


    private void HandleSpeedBoost()
    {
        if (_isMoving)
        {
            _rb.velocity = new Vector2(_rb.velocity.x + speedBoostPerSecond * Time.deltaTime, _rb.velocity.y);
        }
    }

    private void Jump()
    {
        _rb.velocity = new Vector2(_rb.velocity.x, jumpForce);
        IsJumping = true;
    }

    private void ResetSpeedBuffTimer()
    {
        _speedBuffTimer = runSpeedBuffDuration;
        IsRunning = _isMoving && Mathf.Abs(_rb.velocity.x) > 0.01f;
        IsWalking = _isMoving && Mathf.Abs(_rb.velocity.x) <= 0.01f;
        IsIdle = !_isMoving;
    }

    private void DecreaseSpeedBuffTimer()
    {
        _speedBuffTimer = Mathf.Max(_speedBuffTimer - Time.deltaTime, 0);
        IsRunning = _isMoving && Mathf.Abs(_rb.velocity.x) > 0.01f;
        IsWalking = _isMoving && Mathf.Abs(_rb.velocity.x) <= 0.01f;
        IsIdle = !_isMoving;
    }

    private void UpdateAnimationStates()
    {
            animator.SetBool(animHashWalking, IsWalking);
    }
    
}
