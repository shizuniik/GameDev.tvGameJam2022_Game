using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro; 

public class HUD : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI levelText;
    [SerializeField] TextMeshProUGUI scoreText;
    [SerializeField] TextMeshProUGUI instructionText;
    [SerializeField] TextMeshProUGUI levelChangeText; 

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

        //levelChangeText.text = "Level " + GameManager.Level.ToString();
        //levelChangeText.enabled = true; 
        //Invoke("ShowLevelChange", 1f); 
    }

    public void ScoreTextUpdate()
    {
        instructionText.enabled = false; 

        scoreText.text = GameManager.Score.ToString();
    }

    public void PauseGame()
    {
        if(!GameManager.GamePaused) 
            AudioManager.Instance.Play("PauseIn");
        else
            AudioManager.Instance.Play("PauseOut");

        GameManager.GamePaused = !GameManager.GamePaused;
        Time.timeScale = GameManager.GamePaused ? 0 : 1; 
    }

    void ShowLevelChange()
    {
        levelChangeText.enabled = false; 
    }
}
