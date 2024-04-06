using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 5.0f;
    public float jumpForce = 10.0f;
    private Rigidbody2D rb;
    private bool isGrounded;

    [Header("Animacion")]
    private Animator animator;
    private SpriteRenderer spriteRenderer;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        HandleJumpInput();
    }

    void FixedUpdate()
    {
        Move();
        UpdateAnimationAndSpriteDirection();
    }

    void Move()
    {
        float moveInput = Input.GetAxis("Horizontal");
        if (Mathf.Abs(moveInput) > 0f) // Solo aplicar movimiento si hay entrada
        {
            rb.velocity = new Vector2(moveInput * speed, rb.velocity.y);
        }
    }

    void HandleJumpInput()
    {
        if (Input.GetKeyDown(KeyCode.W) && isGrounded)
        {
            Jump();
        }
    }

    void Jump()
    {
        rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
    }

    void UpdateAnimationAndSpriteDirection()
    {
        animator.SetFloat("Horizontal", Mathf.Abs(rb.velocity.x));
        spriteRenderer.flipX = rb.velocity.x < 0;
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }
    }

    void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = false;
        }
    }
}
