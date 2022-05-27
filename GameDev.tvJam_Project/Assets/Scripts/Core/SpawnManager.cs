using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField] List<GameObject> listPowerups;
    [SerializeField] List<GameObject> listEnemies;
    [SerializeField] List<GameObject> listObstacles;

    [SerializeField] float powerupSpawnRate;
    [SerializeField] float obstacleSpawnRate;
    [SerializeField] float enemySpawnRate;
    [SerializeField] float powerupTime;
    [SerializeField] float obstacleTime;
    [SerializeField] float enemyTime;

    public static SpawnManager Instance; 

    private void Start()
    {
        if (Instance == null)
        {
            Instance = this; 
        }
        else
        {
            Destroy(gameObject);
            return; 
        }
        DontDestroyOnLoad(gameObject);

        ChangeSpawnRate(GameManager.Level); 
    }

    public void CancelSpawn()
    {
        CancelInvoke("SpawnPowerups");
        CancelInvoke("SpawnObstacles");
        CancelInvoke("SpawnEnemies");
    }

    public void ChangeSpawnRate(int level)
    {
        switch(level)
        {
            case 1:
                InvokeRepeating("SpawnPowerups", powerupTime, powerupSpawnRate);
                InvokeRepeating("SpawnObstacles", obstacleTime, obstacleSpawnRate);
                InvokeRepeating("SpawnEnemies", enemyTime, enemySpawnRate);
                break;

            case 2:
                CancelSpawn(); 

                InvokeRepeating("SpawnPowerups", powerupTime, powerupSpawnRate * 0.4f);
                InvokeRepeating("SpawnObstacles", obstacleTime, obstacleSpawnRate * 0.4f);
                InvokeRepeating("SpawnEnemies", enemyTime, enemySpawnRate * 0.4f);
                break;
            case 3:
                CancelSpawn();

                InvokeRepeating("SpawnPowerups", powerupTime, powerupSpawnRate * 0.2f);
                InvokeRepeating("SpawnObstacles", obstacleTime, obstacleSpawnRate * 0.2f);
                InvokeRepeating("SpawnEnemies", enemyTime, enemySpawnRate * 0.2f);
                break;
            default:
                break; 
        }
    }

    public void SpawnEnemies()
    {
        GameObject enemy = listEnemies[Random.Range(0, listEnemies.Count)];
        Instantiate(enemy, RandomSpawnPos(false), enemy.transform.rotation); 
    }

    public void SpawnObstacles()
    {
        GameObject obstacle = listObstacles[Random.Range(0, listObstacles.Count)];
        Instantiate(obstacle, RandomSpawnPos(true), obstacle.transform.rotation);
    }

    public void SpawnPowerups()
    {
        GameObject powerup = listPowerups[Random.Range(0, listPowerups.Count)];
        Instantiate(powerup, RandomSpawnPos(false), powerup.transform.rotation);
    }

    private Vector3 RandomSpawnPos(bool fixedY)
    {
        Vector3 pos; 

        if (fixedY)
        {
            int randomInt = Random.Range(0, 1);
            float y = randomInt == 0 ? Bounds.yMin: Bounds.yMax;

            pos = new Vector3(Bounds.xMax, y - 0.5f, Bounds.zMin); 
        }
        else
        {
            pos = new Vector3(Bounds.xMax, Random.Range(Bounds.yMin, Bounds.yMax - 2), Bounds.zMin); 
        }

        return pos; 
    }


   
}
