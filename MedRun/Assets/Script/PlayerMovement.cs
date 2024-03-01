using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerMovement : MonoBehaviour
{

    public float moveSpeed = 5f;
    public float jumpForce = 12f;

    public LayerMask groundLayer;
    public Transform groundCheck;
    // public Transform wallCheck;
    public float groundCheckRadius = 0.2f;
    public bool isGrounded;
    // public bool isTouchingWall;

    private Rigidbody2D rb;
    private float horizontalInput;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        if (groundCheck == null)
        {

            Debug.LogError("Groundcheck is not assigned to player controller.");
        }
    }

    // Update is called once per frame
    void Update()
    {
        //Get input values for horizontal movement
        horizontalInput = Input.GetAxis("Horizontal");

        //check for jump input
        if (Input.GetButtonDown("Jump") && isGrounded)
        {

            //Apply an upward force for jumping
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);

        }
    }

    void FixedUpdate()
    {
        //move the player using rigidbody2d in FixedUpdate
        rb.velocity = new Vector2(horizontalInput * moveSpeed, rb.velocity.y);

        // check if the player is grounded
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, groundLayer);

        // isTouchingWall = Physics2D.OverlapCircle(wallCheck.position, wallCheckRadius, groundLayer);


       /* if (horizontalInput > 0)
        {
            transform.localScale = new Vector3(1f, 1f, 1f);

        }

        else if (horizontalInput < 0)
        {
            transform.localScale = new Vector3(-1f, 1f, 1f);
        }
        */
    }

}
