using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShoot : MonoBehaviour
{
    [SerializeField] private Rigidbody bullet;

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
            clone.AddForce(Vector3.down * 1000f);
            float random;
            random = Random.Range(1, 8f);
            yield return new WaitForSeconds(random);
        }
    }
}
