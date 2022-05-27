using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; 

public class GameManager : MonoBehaviour
{
    [SerializeField] int maxScoreLevel1;
    [SerializeField] int maxScoreLevel2;
    [SerializeField] int maxScoreLevel3;

    public static int Score { get; set; }
    public static bool GameEnded;
    public static bool GameOver;
    public static bool GameStarted;
    public static bool GamePaused; 

    public static int Level { get; set; }
    public static GameManager Instance;

    public delegate void ChangeScore(); 
    public static event ChangeScore OnChangeScore;
    public static event ChangeScore OnChangeLevel;

    private void Awake()
    {
        Level = 1;
        Score = 0; 
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

        OnChangeScore?.Invoke();

        CheckGameOver(); 
        CheckLevel();
        CheckWinGame(); 
    }
    
    private void CheckLevel()
    {
        if (Score > maxScoreLevel1 && Score <= maxScoreLevel2 && Level != 2||
           Score > maxScoreLevel2 && Score <= maxScoreLevel3 && Level != 3)
        {
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
            GameEnded = true;
            SpawnManager.Instance.CancelSpawn(); 
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 2); 
            Debug.Log("WinGame"); 
        }
    }

    public void GameOverScene()
    {
        Debug.Log("GameOver");
        GameOver = true;
        SpawnManager.Instance.CancelSpawn();
        SceneManager.LoadScene(2);
    }
}
