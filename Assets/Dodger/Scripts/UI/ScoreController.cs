using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreController : MonoBehaviour
{

    public TextMeshProUGUI scoreLabel;
    public TextMeshProUGUI finalScoreLabel;

    public EnemySpawn spawnManager;

    private int score = 0;

    void Update()
    {
        scoreLabel.text = score.ToString();
    }

    public int GetScore()
    {
        return score;
    }

    public void IncreaseScore()
    {
        score++;

        if (score % 15 == 0)
            spawnManager.IncreaseDifficulty();
    }

    public void ResetScore()
    {
        score = 0;
    }

    public void SetFinalScore()
    {
        finalScoreLabel.text = score.ToString();

        int highScore = PlayerPrefs.GetInt("Score");
        if (score > highScore)
            PlayerPrefs.SetInt("Score", score);
    }
    
}
