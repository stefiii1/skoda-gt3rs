using UnityEngine;

public class Ball : MonoBehaviour
{
    public float speed = 6f;
    public Vector2 startDirection = new Vector2(1f, 1f);

    Rigidbody2D rb;
    Vector2 velocity;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        velocity = startDirection.normalized * speed;
    }

    void FixedUpdate()
    {
        rb.linearVelocity = velocity;
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        Vector3 normal = collision.GetContact(0).normal;
        velocity = Vector3.Reflect(velocity, normal);
    }
}