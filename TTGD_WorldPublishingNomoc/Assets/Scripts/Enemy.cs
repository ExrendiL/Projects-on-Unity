using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private static bool go_left = false;
   private float speed = 6f;
 
    private void Update()
    {
        if (go_left)
        {
            transform.position -= Vector3.right * speed * Time.deltaTime;
        }
        else
        {
            transform.position += Vector3.right * speed * Time.deltaTime;
        }
        
    }
    

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Left_wall")
        {
            go_left = false;
        }
       else if (other.tag == "Right_wall")
        {
            go_left = true;
        }
    }
}
