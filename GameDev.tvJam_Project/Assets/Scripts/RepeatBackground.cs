using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RepeatBackground : MonoBehaviour
{
    [SerializeField] float xVel;
    [SerializeField] float yVel; 

    private Material material;
    private Vector2 offset; 

    private void Awake()
    {
        material = transform.GetComponent<Renderer>().material; 
    }

    // Update is called once per frame
    void Update()
    {
        offset = new Vector2(xVel, yVel);
        material.mainTextureOffset += offset * Time.deltaTime; 
    }
}
