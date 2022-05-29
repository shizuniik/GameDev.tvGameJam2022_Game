using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro; 

public class EnemyScript : MonoBehaviour
{
    [SerializeField] List<float> speedLevel;
    [SerializeField] int damage;
    [SerializeField] GameObject damageText;

    private bool collided = false; 
    private void Update()
    {
        Movement();

        if (transform.position.x < Bounds.xMin)
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
        //float speed = speedLevel[GameManager.Level - 1]; //(GameManager.Level == speedLevel.Count) ? speedLevel[GameManager.Level - 1] : speedLevel[speedLevel.Count - 1];
        transform.Translate(Vector3.left * speed * Time.deltaTime);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.CompareTag("Player") && !collided)
        {
            AudioManager.Instance.Play("EnemySound");
            ShowDamage();
            GameManager.Instance.AddPoints(-damage);
            collided = true; 
        }
    }

    private void ShowDamage()
    {
        GameObject prefab = Instantiate(damageText, transform.position, Quaternion.identity);
        prefab.GetComponent<TextMesh>().text = "-" + damage;
    }
}
