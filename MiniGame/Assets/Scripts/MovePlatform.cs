using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class MovePlatform : MonoBehaviour
{
    private Rigidbody rb;
    public float speed = 100f;

   private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        Debug.Log("Pashe");
        rb.velocity = Vector3.back * speed * Time.deltaTime; 
    }

}
