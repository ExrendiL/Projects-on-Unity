using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyHealth : MonoBehaviour
{
    public float health = 100f, force = 150f, forceTorque = 10f;
    public bool mummy_death;
    private Rigidbody rb;
    public GameObject healthBar;
    public GameObject[] mummyParts;
    public Color materColor;
    public bool canHeal = true;
    private AudioSource audio;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        audio = GetComponent<AudioSource>();
    }

    public void takeDamage(float damage)
    {
        health -= damage;
        if(healthBar != null)
            healthBar.transform.localScale = new Vector3(health/ 100f , 0.1f, 0.1f);
        if (health <= 0 && !mummy_death)
        {
            mummy_death = true;
            audio.Play();
            setNewColor(materColor);

            Destroy(healthBar);
            GetComponent<Animator>().enabled = false;
            GetComponent<SphereCollider>().enabled = false;
            GetComponent<NavMeshAgent>().enabled = false;

            rb.constraints = RigidbodyConstraints.None;
            rb.AddForce(Vector3.up * force);
            rb.AddTorque(Vector3.back * forceTorque);
        }
    }

    public void setNewColor(Color color)
    {
        foreach (GameObject obj in mummyParts)
        {
            obj.GetComponent<SkinnedMeshRenderer>().material.color = color;
        }
    } 
}
