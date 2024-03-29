using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerupScript : MonoBehaviour
{
    [SerializeField] int points;
    [SerializeField] List<float> speedLevel;
    [SerializeField] GameObject pointsText; 

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
        float speed;
        if (GameManager.Level > speedLevel.Count)
        {
            speed = speedLevel[speedLevel.Count - 1];
        }
        else
        {
            speed = speedLevel[GameManager.Level - 1];
        }
        //float speed = speedLevel[GameManager.Level - 1];//(GameManager.Level == speedLevel.Count) ? speedLevel[GameManager.Level - 1] : speedLevel[speedLevel.Count - 1];
        transform.Translate(Vector3.left * speed * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player") && !GameManager.GameEnded && !GameManager.GameOver)
        {
            AudioManager.Instance.Play("PowerupSound");
            ShowPoints(); 
            GameManager.Instance.AddPoints(points); 
            Destroy(gameObject); 
        }
    }

    private void ShowPoints()
    {
        GameObject prefab = Instantiate(pointsText, transform.position, Quaternion.identity); 
        prefab.GetComponent<TextMesh>().text = "+" + points;
    }
}
