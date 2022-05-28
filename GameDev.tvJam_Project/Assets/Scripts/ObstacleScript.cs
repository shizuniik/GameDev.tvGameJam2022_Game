using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleScript : MonoBehaviour
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
        float speed = speedLevel[GameManager.Level - 1];
        transform.Translate(Vector3.left * speed * Time.deltaTime);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.CompareTag("Player") && !collided)
        {
            ShowDamage();
            GameManager.Instance.AddPoints(-damage);
            collided = true; 
        }
    }

    private void ShowDamage()
    {
        Vector3 pos = new Vector3(transform.position.x, transform.position.y + 0.5f, transform.position.z); 
        GameObject prefab = Instantiate(damageText, pos, Quaternion.identity);
        prefab.GetComponent<TextMesh>().text = "-" + damage;
    }
}
