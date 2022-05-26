using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] float force; 

    private Rigidbody playerRb; 
    // Start is called before the first frame update
    void Start()
    {
        playerRb = transform.GetComponent<Rigidbody>(); 
    }

    // Update is called once per frame
    void Update()
    {
        Movement();
        PositionLimits();
    }

    private void Movement()
    {
        if(Input.GetButtonDown("Fire1") || Input.GetButtonDown("Jump"))
        {
            playerRb.AddForce(Vector3.up * force, ForceMode.Impulse);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.transform.CompareTag("Enemy"))
        {
            GameManager.Instance.GameOverScene(); 
        }
    }

    private void PositionLimits()
    {
        if (transform.position.y < Bounds.yMin)
            transform.position = new Vector3(transform.position.x, Bounds.yMin, transform.position.z);

        if (transform.position.y > Bounds.yMax)
        {
            transform.position = new Vector3(transform.position.x, Bounds.yMax, transform.position.z);
            playerRb.AddForce(Vector3.down * force, ForceMode.Impulse);
        }
    }
}
