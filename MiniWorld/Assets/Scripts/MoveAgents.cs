using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class MoveAgents : MonoBehaviour
{
    private NavMeshAgent agent;
    public Transform[] positions;
    private Transform nowPlace;

    private void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        setNewPath();
    }

   public  void setNewPath()
    {
        Transform moveTo = positions[Random.Range(0, positions.Length)];
        if (nowPlace != null && nowPlace.position == moveTo.position)
        {
            setNewPath();
            return;
        }
        nowPlace = moveTo;
        agent.SetDestination(moveTo.position);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Dots"))
        {
            setNewPath();
        }
        
    }

    //private void Update()
    //{
        
    //}
}
