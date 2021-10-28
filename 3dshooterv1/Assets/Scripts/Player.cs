using UnityEngine;
using System.Collections;
using UnityEngine.Networking;

public class Player : NetworkBehaviour
{
    public GameObject plr;

    [SerializeField]
    private float maxHealth = 100f;
    [SyncVar]
    private float currHealth;

     void Awake()
    {
        currHealth = maxHealth;
    }

    public void TakeDamage(float damage)
    {
        currHealth -= damage;
        Debug.Log(transform.name + "current health lavel - " + currHealth);

        if (currHealth == 0)
        {
            Destroy(plr);

          //  StartCoroutine(WaitForResp());
        }

        //IEnumerator WaitForResp()
        //{

        //    Instantiate(plr);

        //    // через 3 секунды
        //    yield return new WaitForSeconds(3f);
        //}



    }
}
