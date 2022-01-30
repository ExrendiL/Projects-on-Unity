using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class CheckController : MonoBehaviour
{
    [SerializeField] private GameObject ball;
    [SerializeField] private GameObject obstacles;
    public static bool readyToMove;
    private bool spawnBall;
    private void Update()
    {
        if (GameObject.Find("Obstacle") == null && GameObject.Find("FireBall(Clone)"))
        {
            //readyToMove = true;
            //Debug.Log(readyToMove);
            Destroy(GameObject.Find("FireBall(Clone)"));

          
        }
       else if (GameObject.Find("Obstacle") == null )
        {
            readyToMove = true;

        }
        else if (GameObject.Find("Obstacle") && GameObject.Find("FireBall(Clone)") == null)
        {

            spawnBall = true;
            readyToMove = false;
        }
        if (spawnBall == true)
        {

            Instantiate(ball);


        }
        if (GameObject.Find("FireBall(Clone)"))
        {
            spawnBall = false;
        }
        if (GameObject.Find("Player") == null && GameObject.Find("FireBall(Clone)"))
        {
            spawnBall = false;
            Destroy(GameObject.Find("FireBall(Clone)"));
        }

    }
   


}




