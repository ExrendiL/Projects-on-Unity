using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeCam : MonoBehaviour
{
    public Camera camera1;
    public Camera camera2;


void Start()
    {
        camera1.enabled = true;
        camera2.enabled = false;
      
}

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.G))
        {
            camera1.enabled = true;
            camera2.enabled = false;
         
    }
        else if (Input.GetKeyDown(KeyCode.H))
        {
            camera1.enabled = false;
            camera2.enabled = true;
           
    }
       
}
}
