using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleScript : MonoBehaviour
{
    [SerializeField] float force; 

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.CompareTag("Player"))
        {
            Debug.Log("choca obst�culo");
            collision.transform.GetComponent<Rigidbody>().AddForce((collision.transform.position - transform.position) * force, ForceMode.Impulse);
        }
    }
}
