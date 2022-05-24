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

    private void Update()
    {
        Movement();
        RestartLastPosition(); 
    }

    private void Movement()
    {
        transform.Translate(Input.GetAxis("Horizontal") * Vector3.right * Time.deltaTime * speedH);
        transform.Translate(Input.GetAxis("Vertical") * Vector3.forward * Time.deltaTime * speedV);

        if(Input.GetButtonDown("Jump") && onFloor)
        {
            transform.GetComponent<Rigidbody>().AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            onFloor = false; 
        }

        BackwardLimit(); 
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.CompareTag("Floor"))
        {
            onFloor = true;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        lastPos = other.transform.position; 
    }

    private void RestartLastPosition()
    {
        if(transform.position.y < Bounds.yMin)
        {
            Vector3 pos = new Vector3(lastPos.x, lastPos.y + 2, lastPos.z);
            transform.position = pos; 
        }
    }

    private void BackwardLimit()
    {
        if(transform.position.z < lastPos.z)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, lastPos.z); 
        }
    }
}
