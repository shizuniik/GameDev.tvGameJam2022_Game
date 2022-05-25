using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    [SerializeField] float speed;

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
