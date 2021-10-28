using UnityEngine;
using System.Collections;
using UnityEngine.Networking;

[RequireComponent(typeof(AudioSource))]
public class PlayerShoot : NetworkBehaviour
    {
    [SerializeField]
    public AudioSource audioData;

    public Weapons weapons;

    [SerializeField]
    private Camera cam;

    [SerializeField]
    private LayerMask mask;

    void Start()
    {
        audioData = GetComponent<AudioSource>();
      
        

        if (cam == null)
        {
            Debug.LogError("PlayerShoot : no camera!");
            this.enabled = false;
        }

        StartCoroutine(WaitForShoot());
    }
    

    IEnumerator WaitForShoot()
    {
        while (true)
        {
            if (Input.GetButton("Fire1"))
            {

                Shoot();
            }

            // Повторяем цикл через 0.5 секунды
            yield return new WaitForSeconds(0.5f);
        }
    }

    [Client]
    void Shoot()
    {
        if (Input.GetButton("Fire1"))
        {

            audioData.Play(0);
        }
       

        RaycastHit _hit;
        if (Physics.Raycast(cam.transform.position, cam.transform.forward, out _hit, weapons.range, mask))
        {
            if (_hit.collider.tag == "Player")
                CmdPlayerShoot(_hit.collider.name, weapons.damage);
        }
    }

    [Command]
    void CmdPlayerShoot(string _ID, float damage)
    {

        Debug.Log("In player"+_ID + " was shooted");
        Player player = GameManager.GetPlayer(_ID);
        player.TakeDamage(damage);
    }
}
