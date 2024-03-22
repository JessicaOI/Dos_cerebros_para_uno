using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class jugador2 : MonoBehaviour
{
    public float speed = 5f;
    public float jumpForce = 10f;
    private Rigidbody2D rb;
    private bool isGrounded;
    public Transform groundCheck;
    public float groundCheckRadius = 0.2f;
    public LayerMask groundLayer;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        Move();
        Jump();

        if (Input.GetKeyDown(KeyCode.S))
        {
            // Intenta bajar por la plataforma.
            // Necesitarás referenciar aquí el Collider2D de tu jugador.
            StartCoroutine(DropDown());
        }
    }

    void Move()
    {
        float moveInput = Input.GetAxisRaw("Horizontal");
        rb.velocity = new Vector2(moveInput * speed, rb.velocity.y);

        if (moveInput != 0)
        {
            transform.localScale = new Vector3(Mathf.Sign(moveInput), 1f, 1f);
        }
    }

    void Jump()
    {
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, groundLayer);

        if (Input.GetKeyDown(KeyCode.W) && isGrounded)
        {
            rb.velocity = Vector2.up * jumpForce;
        }
    }

    IEnumerator DropDown()
    {
        // Desactiva brevemente el collider para bajar.
        Collider2D collider = GetComponent<Collider2D>();
        if (collider != null)
        {
            collider.enabled = false;
            yield return new WaitForSeconds(0.5f); // Ajusta este tiempo según sea necesario.
            collider.enabled = true;
        }
    }
}
