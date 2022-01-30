using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Shooting : MonoBehaviour
{
   [SerializeField] private GameObject player;
    [SerializeField] private GameObject track;
     private GameObject ball;
    private Transform _ball;
    private Vector3 scale; 
    private Vector3 newscale;
    private Vector3 scale1;
    private Vector3 newscale1;
    private Vector3 scale2;
    private Vector3 newscale2;
    private bool fire;
    private float speed = 4f;
    public float speedBall = 8f;
    void Start()
    {
        scale = new Vector3(player.transform.localScale.x, player.transform.localScale.y, player.transform.localScale.z); // Проверяем текущий размер
        newscale = scale;
        scale1 = new Vector3(track.transform.localScale.x, track.transform.localScale.y, track.transform.localScale.z); // Проверяем текущий размер
        newscale1 = scale1;
       
        addPhysicsRaycaster();
    }

   private void Update()
    {
        if (GameObject.Find("FireBall(Clone)"))
        {
            ball = GameObject.Find("FireBall(Clone)") as GameObject;
            _ball = ball.GetComponent<Transform>();

        }
        else if (GameObject.Find("FireBall(Clone)") == null)
        {
            ball = GameObject.Find("Sphere") as GameObject;
            _ball = ball.GetComponent<Transform>();
        }
        if (ball.transform.localScale.x > 0.6f) //&& ball.transform.localScale.x != 
        {
            _ball.transform.Translate(Vector3.left * speedBall * Time.deltaTime);
        }
       
        if (player.transform.localScale.y <= 0.7f)
        {
            Destroy(player);
            Destroy(ball);
        }
        if (ball.transform.localScale.y >= 2.8f) 
        {
            Destroy(player);
            Destroy(ball);
        }
        if (fire == true)
        {
            OnMouseDown();
        }
        if (fire == false)
        {
            OnMouseUp();
        }
       
    }
    
    public void OnMouseDown()
    {

        player.transform.localScale = Vector3.Lerp(player.transform.localScale, newscale, Time.deltaTime * speed);
        track.transform.localScale = Vector3.Lerp(track.transform.localScale, newscale1, Time.deltaTime * speed);
        ball.transform.localScale = Vector3.Lerp(ball.transform.localScale, newscale2, Time.deltaTime * speed);
        newscale = new Vector3(0.5f, 0.5f, 0.5f); 
        newscale1 = new Vector3(track.transform.localScale.x, track.transform.localScale.y, 0.5f);
        newscale2 = new Vector3(3f, 3f, 3f); 
        fire = true;
      

    }

    public void OnMouseUp()
    {
        scale = new Vector3(player.transform.localScale.x, player.transform.localScale.y, player.transform.localScale.z); 
        newscale = scale;
        scale1 = new Vector3(track.transform.localScale.x, track.transform.localScale.y, track.transform.localScale.z); 
        newscale1 = scale1;
        scale2 = new Vector3(ball.transform.localScale.x, ball.transform.localScale.y, ball.transform.localScale.z); 
        newscale2 = scale2;

        fire = false;
        
    }


    void addPhysicsRaycaster()
    {
        PhysicsRaycaster physicsRaycaster = GameObject.FindObjectOfType<PhysicsRaycaster>();
        if (physicsRaycaster == null)
        {
            Camera.main.gameObject.AddComponent<PhysicsRaycaster>();
        }
    }
}
