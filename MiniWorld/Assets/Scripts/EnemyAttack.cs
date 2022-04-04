using UnityEngine;
using UnityEngine.AI;
using System.Collections;

public class EnemyAttack : MonoBehaviour
{
    private NavMeshAgent agent;
    public float damage = 10f;
    private Coroutine dmg;
    private Animator anim;

    private void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        anim = GetComponent<Animator>();
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            agent.SetDestination(other.transform.parent.gameObject.transform.position);
        }
        if (other.CompareTag("Attack"))
        {
            if (dmg == null)
            {
                dmg = StartCoroutine(setDamage(other));
                anim.SetBool("isAttack", true);
            }
        }
    }

     IEnumerator setDamage(Collider other)
    {
        while (true)
        {
            other.transform.parent.GetComponent<PlayerHealth>().takeDamage(damage);
            yield return new WaitForSeconds(0.5f);
        }
         
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            GetComponent<MoveAgents>().setNewPath();
        }

        if (other.CompareTag("Attack"))
        {
            StopCoroutine(dmg);
            dmg = null;
            anim.SetBool("isAttack", false);
        }
    }


    //private void Update()
    //{
        
    //}
}
