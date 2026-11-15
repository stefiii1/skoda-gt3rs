using UnityEngine;

public class Trampoline : MonoBehaviour
{
    public float moveSpeed = 8f;
    public float bounceForce = 14f;
    public float sideSpeed = 6f;
    public float maxGravity = 4f;

    Rigidbody2D rb;
    BoxCollider2D box;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        box = GetComponent<BoxCollider2D>();
    }

    void Update()
    {
        float move = Input.GetAxisRaw("Horizontal");
        rb.linearVelocity = new Vector2(move * moveSpeed, 0);
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        Rigidbody2D ballRb = col.gameObject.GetComponent<Rigidbody2D>();
        if (ballRb == null) return;

        
        if (col.transform.position.y < transform.position.y) return;
        float halfWidth = box.bounds.extents.x;
        float offset = (col.transform.position.x - transform.position.x) / halfWidth;
        offset = Mathf.Clamp(offset, -1f, 1f);

        ballRb.linearVelocity = new Vector2(offset * sideSpeed, bounceForce);

        ScoreManager.instance.AddPoint();
    }
}