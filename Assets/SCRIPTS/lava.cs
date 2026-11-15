using UnityEngine;
using UnityEngine.SceneManagement;

public class lava : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "Player")
        {
            Debug.Log("Lost");
            Time.timeScale = 0f;
            SceneManager.LoadScene(1);
        }
    }
}