using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    // Generic player variables
    Rigidbody2D rb;
    BoxCollider2D playerFeetCollider;

    // Variables related to horizaontal movement
    [SerializeField] float moveSpeed = 20f;
    Vector2 moveInput;

    // Variables associated with player jumping
    bool isGrounded;
    [SerializeField] float jumpForce = 30f;
    int maxJumpCount = 1;
    int jumpCount = 1;

    // Variables associated with player dashing


    //Variables associated with Player Animation
    private Animator anim;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        playerFeetCollider = GetComponent<BoxCollider2D>();

    }

    void Start()
    {
        isGrounded = true;
    }

    
    void Update()
    {
        PlayerRun();
        FlipPlayer();
        CheckGround();
    }
    
    void OnMove(InputValue value)
    {
        moveInput = value.Get<Vector2>();
    }

    void OnJump(InputValue value)
    {
        if (!CheckGround() && jumpCount == maxJumpCount)
        {
            return;
        }   
        if (value.isPressed)
        {
            jumpCount++;
            PlayerJump();
        }
    }

    void PlayerRun()
    {
        Vector2 playerVelocity = new Vector2(moveInput.x * moveSpeed, rb.velocity.y);
        rb.velocity = playerVelocity;

        bool playerHasHorizontalSpeed = Mathf.Abs(rb.velocity.x) > Mathf.Epsilon;
        anim.SetBool("isRunning", playerHasHorizontalSpeed);
    }

    void FlipPlayer()
    {
        bool playerHasHorizontalSpeed = Mathf.Abs(rb.velocity.x) > Mathf.Epsilon;
        if (playerHasHorizontalSpeed)
        {
            transform.localScale = new Vector2(Mathf.Sign(rb.velocity.x), 1f);
        }
    }

    void PlayerJump()
    {     
        rb.velocity = new Vector2(rb.velocity.x, jumpForce);  
    }

    bool CheckGround()
    {
        if (playerFeetCollider.IsTouchingLayers(LayerMask.GetMask("Ground")))
        {
            Debug.Log(isGrounded);
            isGrounded = true;
            jumpCount = 1;
        }
        else
        { 
            isGrounded = false;
        }
        anim.SetBool("isGrounded", isGrounded);
        return isGrounded;
    }
}
