using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 5.0f; // Velocidad de movimiento lateral
    public float jumpForce = 10.0f; // Fuerza del salto
    private Rigidbody2D rb;
    private bool isGrounded; // Verificar si el jugador está en el suelo

    [Header("Animacion")]
    private Animator animator;
    private SpriteRenderer spriteRenderer; // Agregamos un SpriteRenderer para controlar la orientación del sprite

    void Start()
    {
        rb = GetComponent<Rigidbody2D>(); // Obtenemos el componente Rigidbody2D del jugador
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>(); // Obtenemos el SpriteRenderer del jugador
    }

    void Update()
    {
        Move();
        if (Input.GetKeyDown(KeyCode.W) && isGrounded)
        {
            Jump();
        }

        animator.SetFloat("Horizontal", Mathf.Abs(rb.velocity.x)); // Actualizamos la animación horizontal

        // Cambiamos la escala del sprite según la dirección de movimiento
        if (rb.velocity.x > 0)
        {
            spriteRenderer.flipX = false; // No voltear el sprite
        }
        else if (rb.velocity.x < 0)
        {
            spriteRenderer.flipX = true; // Voltear el sprite
        }
    }

    void Move()
    {
        float moveInput = Input.GetAxis("Horizontal"); // Obtiene el input de movimiento lateral (-1, 0, 1)
        rb.velocity = new Vector2(moveInput * speed, rb.velocity.y); // Aplica el movimiento
    }

    void Jump()
    {
        rb.velocity = Vector2.up * jumpForce; // Aplica la fuerza de salto
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground")) // Asegúrate de que tu suelo tenga el tag "Ground"
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
