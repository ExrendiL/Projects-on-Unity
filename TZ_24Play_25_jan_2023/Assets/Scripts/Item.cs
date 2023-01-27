using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            CubeStack cubeStack;
            if (other.TryGetComponent(out cubeStack))
            {
                cubeStack.AddNewItem(this.transform);
            }
        }
        if (other.CompareTag("Cube"))
        {
           // Destroy(gameObject);
            CubeStack cubeStack1;
            if (other.TryGetComponent(out cubeStack1))
            {
                Debug.Log("df");
                cubeStack1.DelItem(transform);
            }
           
        }
    }

}
