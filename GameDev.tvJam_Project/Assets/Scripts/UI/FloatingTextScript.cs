using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloatingTextScript : MonoBehaviour
{
    [SerializeField] float destroyTime; 
    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, destroyTime); 
    }

    private void SetInactive()
    {
        gameObject.SetActive(false); 
    }
}
