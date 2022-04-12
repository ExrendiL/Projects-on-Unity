using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    public float damage = 20f;
    private bool attack;
    private Collider mummy;
    private Animator anim;
    private AudioSource audio;


    private void Start()
    {
        anim = transform.parent.GetComponent<Animator>();
        audio = GetComponent<AudioSource>();
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0) && attack && mummy != null && !PlayerHealth.death)
        {
            mummy.GetComponent<EnemyHealth>().takeDamage(damage);
            anim.SetTrigger("Attack");
            audio.Play();
        }
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            attack = true;
            mummy = other;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            attack = false;
            mummy = null;
        }
    }





}
