using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerupScript : MonoBehaviour
{
    [SerializeField] int points;
    [SerializeField] List<float> speedLevel; 

    private void Start()
    {
        
    }

    private void Update()
    {
        Movement(); 

        if(transform.position.x < Bounds.xMin)
        {
            Destroy(gameObject); 
        }
    }

    private void Movement()
    {
        float speed = speedLevel[GameManager.Level - 1];
        transform.Translate(Vector3.left * speed * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player") && !GameManager.GameEnded && !GameManager.GameOver)
        {
            GameManager.Instance.AddPoints(points); 
            Destroy(gameObject); 
        }
    }
}
