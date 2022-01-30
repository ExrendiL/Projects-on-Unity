using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillFireBall : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {

        if (CompareTag("FireBall"))

        {
            Destroy(gameObject);

        }

    }
}
