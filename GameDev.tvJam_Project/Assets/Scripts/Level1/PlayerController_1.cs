using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController_1 : MonoBehaviour
{
    [SerializeField] float speedH;
    [SerializeField] float speedV;
    [SerializeField] float jumpForce;
    [SerializeField] Transform startPos; 

    private bool onFloor;
    private Vector3 lastPos;

    // Start is called before the first frame update
    void Start()
    {
        onFloor = false;
        lastPos = startPos.position; 
    }

    private void FixedUpdate()
    {
        Movement();
    }

    private void Update()
    {
        RestartLastPosition(); 
        //Jump(); 
        BackwardLimit(); 
    }

    private void Movement()
    {
        transform.GetComponent<Rigidbody>().AddForce(Input.GetAxis("Vertical") * Vector3.forward * speedV * Time.deltaTime, ForceMode.VelocityChange);
        transform.GetComponent<Rigidbody>().AddForce(Input.GetAxis("Horizontal") * Vector3.right * speedH * Time.deltaTime, ForceMode.VelocityChange);
    }

    private void Jump()
    {
        if (Input.GetButtonDown("Jump") && onFloor)
        {
            transform.GetComponent<Rigidbody>().AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            onFloor = false;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.CompareTag("Floor"))
        {
            onFloor = true;
        }

        Debug.Log("choca" + collision.transform.name); 
    }

    private void OnTriggerEnter(Collider other)
    {
        if (transform.position.y > Bounds.yMin)
        {
            lastPos = other.transform.position;
        }

        if(other.CompareTag("Goal"))
        {
            GameManager.Instance.NextScene(); 
        }
    }

    private void RestartLastPosition()
    {
          if(transform.position.y < Bounds.yMin)
          {
              Vector3 pos = new Vector3(lastPos.x, 0.5f, lastPos.z);
              transform.position = pos; 
          }
          else if(transform.position.y > 1.5f)
          {
              Vector3 pos = new Vector3(transform.position.x, 0.5f, transform.position.z);
              transform.position = pos;
          }
        Debug.Log("pos: " + transform.position.y);
    }

    private void BackwardLimit()
    {
        if(transform.position.z < lastPos.z)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, lastPos.z); 
        }
    }
}
