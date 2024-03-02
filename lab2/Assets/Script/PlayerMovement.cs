using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerMovement : MonoBehaviour
{
    private new Rigidbody2D rigidbody2D;
    private new Collider2D collider2D;

    public float moveSpeed = 8f;
    public float jumpForce = 15f;

    private Vector2 velocity;
    private bool isJumping;

    private void Awake()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
        collider2D = GetComponent<Collider2D>();
    }

    private void Update()
    {
        MovePlayer();
        Jump();
    }

    private void MovePlayer()
    {
        float moveInput = Input.GetAxis("Horizontal");
        velocity = new Vector2(moveInput * moveSpeed, rigidbody2D.velocity.y);
        rigidbody2D.velocity = velocity;

        // Flip sprite direction depending on input
        if (moveInput > 0f)
            transform.localScale = new Vector3(1f, 1f, 1f);
        else if (moveInput < 0f)
            transform.localScale = new Vector3(-1f, 1f, 1f);
    }

    private void Jump()
    {
        if (Input.GetButtonDown("Jump") && !isJumping)
        {
            rigidbody2D.AddForce(new Vector2(0f, jumpForce), ForceMode2D.Impulse);
            isJumping = true;
        }
    }

    // Detect collision with the ground
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.contacts[0].normal.y > 0.5f)  // Check if the collision is below Mario
        {
            isJumping = false; // Mario is on the ground
        }
    }
}