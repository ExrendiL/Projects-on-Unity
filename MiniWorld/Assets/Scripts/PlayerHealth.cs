using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public float health = 100f, force = 150f, forceTorque = 100f;
    public static bool death;
    private Rigidbody rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    public void takeDamage(float damage)
    {
        health -= damage;
        if (health <= 0 && !death)
        {
            death = true;
            rb.constraints = RigidbodyConstraints.None;
            rb.AddForce(Vector3.up * force);
            rb.AddTorque(Vector3.back * forceTorque);
        }
    }
}
