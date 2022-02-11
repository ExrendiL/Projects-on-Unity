using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyBullet : MonoBehaviour
{
 

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Bullet" || other.tag == "Bottom")
        {
            Destroy(other.gameObject);
        }

        if (other.tag == "Player")
        {
            Player.lives_count--;

        }
    }
}
