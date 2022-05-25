using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Powerup : MonoBehaviour
{
    [SerializeField] int points;

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player") && !GameManager.GameEnded && !GameManager.GameOver)
        {
            GameManager.Instance.AddPoints(points); 
            Destroy(gameObject); 
        }
    }
}
