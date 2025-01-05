using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public Text scoreText;
    public Text healthText;
    public Text gameOverText;

    private int score = 0;
    private int health = 100;

    void Start()
    {
        UpdateScoreText();
        UpdateHealthText();
        gameOverText.gameObject.SetActive(false);
    }

    public void AddScore(int value)
    {
        score += value;
        UpdateScoreText();
    }

    public void ReduceHealth(int value)
    {
        health -= value;
        UpdateHealthText();
        if (health <= 0)
        {
            ShowGameOver();
        }
    }

    void UpdateScoreText()
    {
        scoreText.text = "Score: " + score;
    }

    void UpdateHealthText()
    {
        healthText.text = "Health: " + health;
    }

    void ShowGameOver()
    {
        gameOverText.gameObject.SetActive(true);
    }
}