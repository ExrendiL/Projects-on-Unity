using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    public float health = 100f, force = 150f, forceTorque = 100f;
    public static bool death;
    private Rigidbody rb;
    public RectTransform healthBar;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    public void takeDamage(float damage)
    {
        if (health <= 0)
            return;
        
        health -= damage;
        setHealthBar();
        if (health <= 0 && !death)
        {
            death = true;
            rb.constraints = RigidbodyConstraints.None;
            rb.AddForce(Vector3.up * force);
            rb.AddTorque(Vector3.back * forceTorque);
        }
    }

    public void setHealthBar()
    {
        healthBar.offsetMax = new Vector2(-1f * 253f * (100f - health) / 100f, 0);
    }
}
