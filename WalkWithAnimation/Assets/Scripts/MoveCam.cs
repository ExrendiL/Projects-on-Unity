using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCam : MonoBehaviour
{
    public float sensitivity = 2f;
    void Update()
    {
        var c = Camera.main.transform;
        
            c.Rotate(-Input.GetAxis("Mouse Y") * sensitivity, 0, 0);
        if (Input.GetMouseButtonDown(0))
            c.Rotate(0, 0, -Input.GetAxis("Mouse Y") * 20 * Time.deltaTime);
    }
}
