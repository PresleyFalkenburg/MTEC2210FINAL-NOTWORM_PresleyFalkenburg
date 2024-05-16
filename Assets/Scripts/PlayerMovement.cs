using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 100f; // Movement speed of the player
    public float jumpPower = 100f; // Force applied when jumping
    public float jetpackForce = 15f; // Upward force applied by the jetpack
    public float cooldownTime = 20f; // Time in seconds for jetpack cooldown

    private float currentCooldown; // Current cooldown timer
    private bool jetpackActive; // Flag indicating if jetpack is currently active

    bool jumpFlag;
    public LayerMask Ground; // Layer mask for the ground objects
    public float xMove;
    public Transform[] raycastPoints;
    private Rigidbody2D rb; // Reference to the player's Rigidbody2D component
    public float rayLength = 0.6f;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        currentCooldown = 0f; // Initialize cooldown to 0 at start
        jetpackActive = false; // Jetpack starts inactive
    }

    private void Update()
    {
        // Handle player movement
        xMove = Input.GetAxis("Horizontal");

        // Handle player jump (remains the same as before)
        if (Input.GetKeyDown(KeyCode.Space) && GroundCheck())
        {
            Debug.Log("jump");
            jumpFlag = true;
        }

        // Handle jetpack activation (with cooldown check)
        if (Input.GetKeyDown(KeyCode.Q) && currentCooldown <= 0f)
        {
            jetpackActive = true;
            currentCooldown = cooldownTime; // Reset cooldown timer on activation
        }
    }

    private void FixedUpdate()
    {
        // Physics and movement

        // Apply horizontal movement
        rb.velocity = new Vector2(xMove * Time.deltaTime * moveSpeed, rb.velocity.y);

        // Apply jump if jump flag is set (remains the same)
        if (jumpFlag)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpPower);
            jumpFlag = false;
        }

        // Apply jetpack force if active
        if (jetpackActive)
        {
            Debug.Log("jet");
            GetComponent<Rigidbody2D>().velocity += Vector2.up * jetpackForce * Time.deltaTime;
        }

        // Decrement cooldown timer
        if (currentCooldown > 0f)
        {
            currentCooldown -= Time.deltaTime;
            jetpackActive = false; // Deactivate jetpack during cooldown
        }

        // Check if player falls below y = -70 and destroy if needed
        if (transform.position.y < -70)
        {
            Destroy(gameObject);
        }
    }

    private bool GroundCheck()
    {
        bool a = Physics2D.Raycast(raycastPoints[0].position, Vector2.down, rayLength, LayerMask.GetMask("Ground"));
        bool b = Physics2D.Raycast(raycastPoints[1].position, Vector2.down, rayLength, LayerMask.GetMask("Ground"));
        bool c = Physics2D.Raycast(raycastPoints[2].position, Vector2.down, rayLength, LayerMask.GetMask("Ground"));
        Debug.Log("ground");
        return a || b || c;

    }
}
