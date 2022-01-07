using System.Collections;
using System.Collections.Generic;
using UnityEngine.AI;
using UnityEngine;

public class GoalTrigg : MonoBehaviour
{
    public GameObject goal;
    public void OnTriggerEnter(Collider col)
    {
        if (col.tag == "Ball")
        {
            Debug.Log("Trigger is working");
            Destroy(col.gameObject);
            Destroy(goal);

        }
    }
    
}
