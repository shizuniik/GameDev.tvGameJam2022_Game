using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    [SerializeField] List<float> speedLevel;

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
        if (collision.transform.CompareTag("Player"))
        {
            Debug.Log("choca enemy");
            
        }
    }
}
