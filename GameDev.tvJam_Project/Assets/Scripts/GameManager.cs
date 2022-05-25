using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; 

public class GameManager : MonoBehaviour
{
    public static int Score { get; set; }
    public static bool GameEnded;
    public static bool GameOver; 
    public static int Level { get; set; }
    public static GameManager Instance;

    private void Awake()
    {
        Level = 1; 
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
    }
    
}
