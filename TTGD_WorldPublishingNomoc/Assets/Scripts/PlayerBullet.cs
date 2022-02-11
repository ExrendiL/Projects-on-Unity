using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerBullet : MonoBehaviour
{
 
    public static int score;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Bullet")
        {
            Destroy(other.gameObject);
        }

        if (other.tag == "Enemy")
        {
            score++;
            Destroy(other.gameObject);
            Destroy(gameObject);
        }
    }
}
