using UnityEngine;

public class BombSpawner : MonoBehaviour
{
    public GameObject bombPrefab;
    public float spawnInterval = 2f;
    public int maxBombs = 3;
    public float lowest = 0.3f;
    public float highest = 0.85f;
    public float sideMargin = 0.08f;

    float timer;
    Camera cam;

    void Start()
    {
        cam = Camera.main;
        timer = spawnInterval;
    }

    void Update()
    {
        timer = timer - Time.deltaTime;
        if (timer > 0) return;

        timer = spawnInterval;

        if (FindObjectsByType<BombPickup>(FindObjectsSortMode.None).Length >= maxBombs) return;

        float vx = Random.Range(sideMargin, 1f - sideMargin);
        float vy = Random.Range(lowest, highest);

        Vector3 pos = cam.ViewportToWorldPoint(new Vector3(vx, vy, 0));
        pos.z = -1;

        Instantiate(bombPrefab, pos, Quaternion.identity);
    }
}