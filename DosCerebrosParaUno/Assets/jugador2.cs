using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(CapsuleCollider2D))]

public class CharacterController2D : MonoBehaviour
{
    public float maxSpeed = 3.4f;
    public float jumpHeight = 6.5f;
    public float gravityScale = 1.5f;

    bool facingRight = true;
    float moveDirection = 0;
    Rigidbody2D r2d;
    CapsuleCollider2D mainCollider;
    Transform t;

    int jumpCount = 0; // Controla el número de saltos
    public int maxJump = 2; // Máximo de saltos permitidos antes de tocar el suelo

    void Start()
    {
        t = transform;
        r2d = GetComponent<Rigidbody2D>();
        mainCollider = GetComponent<CapsuleCollider2D>();
        r2d.freezeRotation = true;
        r2d.collisionDetectionMode = CollisionDetectionMode2D.Continuous;
        r2d.gravityScale = gravityScale;
        facingRight = t.localScale.x > 0;
    }

    void Update()
    {
        moveDirection = 0;
        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D))
        {
            moveDirection = Input.GetKey(KeyCode.A) ? -1 : 1;
        }

        if (moveDirection != 0)
        {
            if (moveDirection > 0 && !facingRight || moveDirection < 0 && facingRight)
            {
                facingRight = !facingRight;
                t.localScale = new Vector3(-t.localScale.x, t.localScale.y, t.localScale.z);
            }
        }

        if (Input.GetKeyDown(KeyCode.W) && jumpCount < maxJump)
        {
            r2d.velocity = new Vector2(r2d.velocity.x, jumpHeight);
            jumpCount++; // Incrementamos el contador de saltos
        }
    }

    void FixedUpdate()
    {
        r2d.velocity = new Vector2(moveDirection * maxSpeed, r2d.velocity.y);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Suelo"))
        {
            jumpCount = 0; // Restablecer el contador de saltos cuando toca el suelo
        }
    }

    // Asegúrate de usar este método para cuando el personaje "deja" el suelo, si es necesario.
    void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Suelo"))
        {
            // Esta línea es opcional, dependiendo de cómo quieras manejar la lógica de tu juego.
            // Podrías querer hacer algo cuando el personaje deja de tocar el suelo.
        }
    }
}
