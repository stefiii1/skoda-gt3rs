using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager instance;

    public TextMeshProUGUI scoreText;

    int score = 0;
    bool won = false;

    void Awake()
    {
        instance = this;
    }

    void Start()
    {
        Time.timeScale = 1f;  
        UpdateText();
    }
    
    public void AddPoint()
{
    AddPoints(1);
}

    public void AddPoints(int amount)
    {
    if (won) return;

    score = score + amount;
    UpdateText();

    if (score >= 25)
    {
        Win();
    }   
    }

    void Win()
    {
        won = true;
        SceneManager.LoadScene(2);
        Time.timeScale = 0f;  
    }

    void UpdateText()
    {
        scoreText.text = "Score: " + score;
    }
}