using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveLeft : MonoBehaviour
{
    [SerializeField] float moveLeftSpeed; 
    // Update is called once per frame
    void Update()
    {
        if(!GameManager.GameEnded && !GameManager.GameOver)
        {
            transform.Translate(Vector3.left * moveLeftSpeed * Time.deltaTime); 
        }
    }
}
