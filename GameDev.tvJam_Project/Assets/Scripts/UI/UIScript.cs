using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; 

public class UIScript : MonoBehaviour
{
    public void StartGame()
    {
        AudioManager.Instance.Play("ClickButton");
        GameManager.Level = 1;
        GameManager.GameStarted = false; 
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1); 
    }

    public void PlayAgain()
    {
        AudioManager.Instance.Play("ClickButton");
        if (GameManager.GameEnded)
        {
            AudioManager.Instance.Stop("CreditsSong");
            AudioManager.Instance.Play("ThemeSong");
        }
        else
        {
            AudioManager.Instance.Stop("GameOverSound");
            AudioManager.Instance.Play("ThemeSong");
        }
        GameManager.GameEnded = false;
        GameManager.GameOver = false;
        GameManager.Score = 0;
        GameManager.Level = 1;
        GameManager.NearMaxScore = false;
        GameManager.GameStarted = true;
        SpawnManager.Instance.ChangeSpawnRate(GameManager.Level); 

        SceneManager.LoadScene(1);
    }
}
