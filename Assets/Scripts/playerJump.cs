using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(Animator))]
public class playerJump : MonoBehaviour
{
    //public variables
    [Header("Jump Details")]
    public float jumpForce;
    // used in bullet script
    public static bool grounded;
    public float jumpTime;
    private float jumpTimeCounter;
    private bool stoppedJumping;
    

    // private variables
    [Header("Ground Details")]
    [SerializeField] private Transform groundCheck;
    [SerializeField] private LayerMask determineGround;
    [SerializeField] private float circleRadius;

    [Header("Components")]
    private Rigidbody2D rigidBod;
    private Animator animator;

    private void Start()
    {
        rigidBod = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        jumpTimeCounter = jumpTime;
    }


    private void Update()
    {
        // assigning to see if player is grounded
        grounded = Physics2D.OverlapCircle(groundCheck.position, circleRadius, determineGround);
        
        if (grounded)
        { 
            jumpTimeCounter = jumpTime;
            animator.ResetTrigger("jump");
            animator.SetBool("falling", false);
        }

        
        animator.SetBool("falling", false);
        
        
        // when button is presses
        if (Input.GetButtonDown("Jump") && grounded)
        {
            // jump
            rigidBod.velocity = new Vector2(rigidBod.velocity.x, jumpForce);
            stoppedJumping = false;
            // tell anim to play animation
            animator.SetTrigger("jump");
        }
        // keep jumping when button is activated
        if (Input.GetButton("Jump") && !stoppedJumping && (jumpTimeCounter > 0))
        {
            // jump
            rigidBod.velocity = new Vector2(rigidBod.velocity.x, jumpForce);
            jumpTimeCounter -= Time.deltaTime;
            animator.SetTrigger("jump");
        }
        // if jump button is released
        if (Input.GetButtonUp("Jump"))
        {
            jumpTimeCounter = 0;
            stoppedJumping = true;
            // we are now falling
            animator.SetBool("falling", true);
            animator.ResetTrigger("jump");
        }
        if (rigidBod.velocity.y < 0)
        {
            animator.SetBool("falling", true);
        }
    }
    private void FixedUpdate()
    {
        HandleLayers();
    }


    private void HandleLayers()
    {
        if (!grounded)
        {
            animator.SetLayerWeight(1, 1);
        }
        else
        {
            animator.SetLayerWeight(1, 0);
        }
    }
}
