using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour
{
    [Header("Movement")]
    public float moveSpeed = 5f;
    public float jumpForce = 7f;

    [Header("Gravity Flip")]
    public float flipCooldown = 0.5f;
    private bool canFlip = true;

    private Rigidbody2D rb;
    private bool isGrounded = false;
    private float defaultGravityScale;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        defaultGravityScale = rb.gravityScale;
    }

    void Update()
    {
        RunForward();
        HandleJump();
        HandleGravityFlip();
    }

    void RunForward()
    {
        rb.linearVelocity = new Vector2(moveSpeed, rb.linearVelocity.y);
    }

    void HandleJump()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, 0);
            rb.AddForce(Vector2.up * jumpForce * Mathf.Sign(rb.gravityScale), ForceMode2D.Impulse);
        }
    }

    void HandleGravityFlip()
    {
        if (Input.GetKeyDown(KeyCode.W) && canFlip)
        {
            StartCoroutine(GravityFlipRoutine());
        }
    }

    private IEnumerator GravityFlipRoutine()
    {
        canFlip = false;

        rb.gravityScale *= -1;      
        // Flip sprite
        transform.localScale = new Vector3(
            transform.localScale.x,
            transform.localScale.y * -1,
            transform.localScale.z
        );

        yield return new WaitForSeconds(flipCooldown);
        canFlip = true;
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Ground"))
            isGrounded = true;
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Ground"))
            isGrounded = false;
    }
}
