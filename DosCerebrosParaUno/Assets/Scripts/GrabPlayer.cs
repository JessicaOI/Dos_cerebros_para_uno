using UnityEngine;

public class GrabPlayer : MonoBehaviour
{
    private GameObject grabbedObject;
    public float throwForce = 15.0f;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q) && grabbedObject != null)
        {
            ThrowGrabbedObject();
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Jugador2"))
        {
            Debug.Log("Jugador2 dentro del área de agarre.");
            grabbedObject = collision.gameObject;
        }
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject == grabbedObject)
        {
            Debug.Log("Jugador2 fuera del área de agarre.");
            grabbedObject = null;
        }
    }

    void ThrowGrabbedObject()
    {
        if (grabbedObject != null)
        {
            Rigidbody2D rbGrabbedObject = grabbedObject.GetComponent<Rigidbody2D>();
            if (rbGrabbedObject != null)
            {
                rbGrabbedObject.velocity = Vector2.up * throwForce;
                Debug.Log("Jugador2 lanzado hacia arriba.");
            }
            grabbedObject = null;
        }
    }
}
