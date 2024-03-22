using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 5.0f; // Velocidad de movimiento lateral
    public float jumpForce = 10.0f; // Fuerza del salto
    private Rigidbody2D rb;
    private bool isGrounded; // Verificar si el jugador está en el suelo

    void Start()
    {
        rb = GetComponent<Rigidbody2D>(); // Obtenemos el componente Rigidbody2D del jugador
    }

    void Update()
    {
        Move();
        if (Input.GetKeyDown(KeyCode.W) && isGrounded)
        {
            Jump();
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
