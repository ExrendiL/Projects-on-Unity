using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePlayer : MonoBehaviour
{
    private Rigidbody rb;
    
    public float speed = 5f;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
       
    }

    void Update()
    {
        if (CheckController.readyToMove)
        {
            Vector3 movement = new Vector3(-5, 0, 0);
            rb.MovePosition(transform.position + movement * Time.fixedDeltaTime);
        }
    }
}
