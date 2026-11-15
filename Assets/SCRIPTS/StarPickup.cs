using UnityEngine;

public class StarPickup : MonoBehaviour
{
    public int points = 2;
    public float lifeTime = 6f;

    void Start()
    {
        Destroy(gameObject, lifeTime);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.GetComponent<Rigidbody2D>() == null) return;
        if (other.GetComponent<Trampoline>() != null) return;

        Debug.Log("stea luata, +" + points);
        ScoreManager.instance.AddPoints(points);
        Destroy(gameObject);
    }
}