using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro; 

public class HUD : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI levelText;
    [SerializeField] TextMeshProUGUI scoreText;
    [SerializeField] TextMeshProUGUI instructionText;

    private void Start()
    {
        instructionText.enabled = !GameManager.GameStarted; 
    }
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
        levelText.text = GameManager.Level.ToString() + "/3";
    }

    public void ScoreTextUpdate()
    {
        instructionText.enabled = false; 

        scoreText.text = GameManager.Score.ToString();
    }

    public void PauseGame()
    {
        AudioManager.Instance.Play("ClickButton");

        GameManager.GamePaused = !GameManager.GamePaused;
        Time.timeScale = GameManager.GamePaused ? 0 : 1; 
    }
}
