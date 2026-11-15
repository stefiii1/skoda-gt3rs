using UnityEngine;

public class BombPickup : MonoBehaviour
{
    public int points = -2;
    public float lifeTime = 3f;

    void Start()
    {
        Destroy(gameObject, lifeTime);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.GetComponent<Rigidbody2D>() == null) return;
        if (other.GetComponent<Trampoline>() != null) return;

        ScoreManager.instance.AddPoints(points);
        Destroy(gameObject);
    }
}