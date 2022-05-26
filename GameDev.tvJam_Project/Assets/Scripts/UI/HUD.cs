using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro; 

public class HUD : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI levelText;
    [SerializeField] TextMeshProUGUI scoreText; 

    private void OnEnable()
    {
        GameManager.OnChangeScore += ScoreTextUpdate;
        GameManager.OnChangeLevel += LevelTextUpdate;
    }

    private void OnDisable()
    {
        GameManager.OnChangeScore -= ScoreTextUpdate;
        GameManager.OnChangeLevel -= LevelTextUpdate; 
    }

    public void LevelTextUpdate()
    {
        levelText.text = GameManager.Level.ToString();
    }

    public void ScoreTextUpdate()
    {
        scoreText.text = GameManager.Score.ToString();
    }

    public void PauseGame()
    {
        GameManager.GamePaused = !GameManager.GamePaused;
        Time.timeScale = GameManager.GamePaused ? 0 : 1; 
    }
}
