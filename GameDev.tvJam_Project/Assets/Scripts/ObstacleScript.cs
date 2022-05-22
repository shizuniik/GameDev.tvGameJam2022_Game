using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    { 
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.CompareTag("Player"))
        {
            Debug.Log("choca obst�culo");
            collision.transform.GetComponent<Rigidbody>().AddForce((collision.transform.position - transform.position) * 10, ForceMode.Impulse);
        }
    }
}
