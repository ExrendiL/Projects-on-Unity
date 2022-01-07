using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameContr : MonoBehaviour
{
    public GameObject obj1, obj2; 



    private void Update()
    {
       
        if (GameObject.Find("Target")  == null && GameObject.Find("Target1") == null && GameObject.Find("Target2") == null)
        {
           
            obj1.SetActive(true);
            obj2.SetActive(false);

        }
        if (GameObject.Find("Cube") == null && GameObject.Find("Cube1") == null)
        {
           
            obj1.SetActive(true);
            obj2.SetActive(false);
        }

    }
  
}
