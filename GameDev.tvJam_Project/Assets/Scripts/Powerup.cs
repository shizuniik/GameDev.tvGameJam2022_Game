using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Powerup : MonoBehaviour
{
    [SerializeField] int points;
    [SerializeField] float speed; 

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
