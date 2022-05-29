using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; 

public class GameManager : MonoBehaviour
{
    [SerializeField] int maxScoreLevel1;
    [SerializeField] int maxScoreLevel2;
    [SerializeField] int maxScoreLevel3;
    [SerializeField] int scoreToEnd; 
    public static int Score { get; set; }
    public static bool GameEnded;
    public static bool GameOver;
    public static bool GameStarted;
    public static bool GamePaused;
    public static bool NearMaxScore; 

    public static int Level { get; set; }
    public static GameManager Instance;

    public delegate void ChangeScore(); 
    public static event ChangeScore OnChangeScore;
    public static event ChangeScore OnChangeLevel;

    private void Awake()
    {
        Level = 1;
        Score = 0;
        NearMaxScore = false; 
    }

    // Start is called before the first frame update
    void Start()
    {
        if(Instance == null)
        {
            Instance = this; 
        }
        else
        {
            Destroy(gameObject);
            return; 
        }
        DontDestroyOnLoad(gameObject); 
    }


    public void NextScene()
    {
        if(!GameEnded && !GameOver)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1); 
        }
    }

    public void AddPoints(int points)
    {
        Score += points;

        CheckGameOver();
        CheckNearMaxScore(); 

        OnChangeScore?.Invoke();

        CheckWinGame();

        CheckLevel();
    }

    private void CheckNearMaxScore()
    {
        NearMaxScore = Score >= maxScoreLevel3 - scoreToEnd;
    }
    
    private void CheckLevel()
    {
        if ((Score > maxScoreLevel1 && Score <= maxScoreLevel2 && Level != 2||
           Score > maxScoreLevel2 && Score <= maxScoreLevel3) 
           && !GameEnded && !GameOver && Level != 3)
        {
            AudioManager.Instance.Play("LevelChangeSound"); 
            Level += 1;
            OnChangeLevel?.Invoke();

            SpawnManager.Instance.ChangeSpawnRate(Level); 
        }
    }

    private void CheckGameOver()
    {
        if(Score < 0)
        {
            GameOverScene(); 
        }
    }

    private void CheckWinGame()
    {
        if(Score >= maxScoreLevel3)
        {
            AudioManager.Instance.Play("WinSound"); 
            GameEnded = true;
            SpawnManager.Instance.CancelSpawn(); 
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 2);
            AudioManager.Instance.Stop("ThemeSong");
            AudioManager.Instance.Play("CreditsSong"); 
            Debug.Log("WinGame"); 
        }
    }

    public void GameOverScene()
    {
        AudioManager.Instance.Stop("ThemeSong");
        AudioManager.Instance.Play("GameOverSound");
        Debug.Log("GameOver");
        GameOver = true;
        SpawnManager.Instance.CancelSpawn();
        SceneManager.LoadScene(2);
    }
}
