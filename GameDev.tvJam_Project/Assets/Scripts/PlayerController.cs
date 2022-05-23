using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] float speedH;
    [SerializeField] float jumpForce;
    [SerializeField] float speedForward;

    [SerializeField] Transform nextPos; 
    private int damage = 1; // REVISAR 
    public int Life { get; private set; }
    private bool onFloor; 

    // Start is called before the first frame update
    void Start()
    {
       onFloor = true; 
       Life = 100; 
    }

    private void Update()
    {
        ForwardMovement();
        SideMovement();
    }

    private void SideMovement()
    {
       transform.Translate(Input.GetAxis("Horizontal") * Vector3.right * Time.deltaTime * speedH);
       transform.Translate(Input.GetAxis("Vertical") * Vector3.forward * Time.deltaTime * speedForward);
    }

    private void ForwardMovement()
    {
        //transform.Translate(Vector3.forward * speedForward * Time.deltaTime);
        //transform.Translate(Input.GetAxis("Vertical") * Vector3.forward * Time.deltaTime * speedV);
        /*if(Input.GetButtonDown("Jump") && onFloor)
        {
            transform.GetComponent<Rigidbody>().AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            onFloor = false; 
        }*/

        Debug.Log("Distance: " + Vector3.Distance(transform.position, nextPos.position));
        if (Input.GetMouseButtonDown(0))
        {
            transform.Translate((nextPos.position - transform.position) * speedForward * Time.deltaTime);
            Debug.Log("Distance after: " + Vector3.Distance(transform.position, nextPos.position));

            if (GameObject.FindGameObjectWithTag("Obs1").transform.position.x >= -12 &&
            GameObject.FindGameObjectWithTag("Obs1").transform.position.x <= -11)
            {
                
                
            }
            else
            {
                Debug.Log("Choca obs"); 
            }
        }
    
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.transform.CompareTag("Tunnel"))
        {
            Damage(damage);
            Debug.Log(Life); 
        }

        if(collision.transform.CompareTag("Floor"))
        {
            onFloor = true; 
        }
    }

    private void Damage(int damage)
    {
        Life -= damage; 
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Level2"))
        {
            GameManager.Level = 2; 
        }
        
        if (other.CompareTag("Level3"))
        {
            GameManager.Level = 3;
        }

    }
}
