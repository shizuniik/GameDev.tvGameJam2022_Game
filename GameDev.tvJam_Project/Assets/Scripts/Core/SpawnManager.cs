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
                CancelSpawn();
                break; 
        }
    }

    public void SpawnEnemies()
    {
        int indx = (GameManager.Level * 3 < listEnemies.Count) ? GameManager.Level * 3 : listEnemies.Count;
        GameObject enemy; 

        if (GameManager.Level == 3 && GameManager.NearMaxScore)
        {
            indx = listEnemies.Count;
            enemy = listEnemies[indx -1];
        }
        else
        {
            enemy = listEnemies[Random.Range(0, indx)];
        }
        Instantiate(enemy, RandomSpawnPos(), enemy.transform.rotation);
    }

    public void SpawnObstacles()
    {
        int indx = (GameManager.Level < listObstacles.Count) ? GameManager.Level : listObstacles.Count;

        // Bottom obstacle
        GameObject obstacle = listObstacles[Random.Range(0, indx)];
        Vector3 pos = RandomSpawnPos();
        pos = new Vector3(pos.x, Bounds.yMin - 0.3f, pos.z); 
        Instantiate(obstacle, pos, obstacle.transform.rotation);

        // Top obstacle
        pos = new Vector3(pos.x, Bounds.yMax + 0.2f, pos.z);
        Quaternion rotation = Quaternion.Euler(180, obstacle.transform.rotation.y, obstacle.transform.rotation.z); 
        Instantiate(obstacle, pos, rotation);
    }

    public void SpawnPowerups()
    {
        int indx = (GameManager.Level < listPowerups.Count) ? GameManager.Level : listPowerups.Count;
        GameObject powerup = listPowerups[Random.Range(0, indx)];
        Instantiate(powerup, RandomSpawnPos(), powerup.transform.rotation);
    }

    private Vector3 RandomSpawnPos()
    {
        return new Vector3(Bounds.xMax, Random.Range(Bounds.yMin + 0.5f, Bounds.yMax - 1f), Bounds.zMin); 
    }


   
}
