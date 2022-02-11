using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Shooting : MonoBehaviour
{
    [SerializeField] private Text current_score;
    [SerializeField] private Text current_score1;

    [SerializeField] private  Rigidbody bullet;


    void Update()
    {
        current_score.text = PlayerBullet.score.ToString();
        current_score1.text = PlayerBullet.score.ToString();
    }
    private void Start()
    {
        StartCoroutine(Shoot());
    }
    IEnumerator Shoot()
    {
        while (true)
        {
            Rigidbody clone;
            clone = Instantiate(bullet, transform.position, transform.rotation);
            clone.AddForce(Vector3.up * 1000f);

            yield return new WaitForSeconds(7f);
        }
    }
}
    
 

