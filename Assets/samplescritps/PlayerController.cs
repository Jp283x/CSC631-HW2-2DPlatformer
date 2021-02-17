using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    private float movementInputDirection;

    private Rigidbody2D rb;
    private Animator anim;

    private bool isFacingRight = true;
    private bool isWalking;
    private bool isGrounded;
    private bool canJump;

    public float mvmtSpeed = 10.0f;
    public float jumpForce = 15.0f;
    public float groundCheckRadius;

    public LayerMask whatIsGround;

    public Transform groundCheck;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        CheckInput();
        CheckMovementDirection();
        UpdateAnimations();
        CheckIfCanJump();
    }

    private void FixedUpdate()
    {
        ApplyMovement();
        CheckSurroundings();
    }

    // Character Movement Input
    private void CheckInput()
    {
        movementInputDirection = Input.GetAxisRaw("Horizontal");

        if (Input.GetButtonDown("Jump"))
        {
            Jump();
        }
    }

    // Jump limiter
    private void CheckIfCanJump()
    {
        if(isGrounded)
        {
            canJump = true;
        }
        else
        {
            canJump = false;
        }
    }

    // Jump Movement
    private void Jump()
    {
        if (canJump)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
        }
    }

    // Movement render
    private void ApplyMovement()
    {
        rb.velocity = new Vector2(mvmtSpeed * movementInputDirection, rb.velocity.y);
    }

    // Flips Sprite Orientation
    private void CheckMovementDirection()
    {
        if(isFacingRight && movementInputDirection < 0)
        {
            Flip();
        }
        else if(!isFacingRight && movementInputDirection > 0)
        {
            Flip();
        }

        if(rb.velocity.x != 0)
        {
            isWalking = true;
        }
        else
        {
            isWalking = false;
        }
    }

    // Sprite Flipper
    private void Flip()
    {
        isFacingRight = !isFacingRight;
        transform.Rotate(0f, 180.0f, 0.0f);
    }


    // Animation Updater
    private void UpdateAnimations()
    {
        anim.SetBool("isWalking", rb.velocity.x > 0.01f || rb.velocity.x < -0.01f);
        anim.SetBool("isGrounded", isGrounded);
        anim.SetFloat("yVelocity", rb.velocity.y);
    }


    // Checks if Player is Grounded
    private void CheckSurroundings()
    {
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, whatIsGround);
    }

    // Radius for Ground Check
    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(groundCheck.position, groundCheckRadius);
    }
}
