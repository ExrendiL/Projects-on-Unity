using UnityEngine;

public class ShootingPlayer : MonoBehaviour {

    public Camera cam;
    public float range = 100f, force = 15f;
    public ParticleSystem shootEffect;

    private void Update() {
        if (Input.GetButtonDown("Fire1"))
            shoot();
    }

    void shoot() {
        shootEffect.Play();
        RaycastHit hit;
        Vector3 shootPos = new Vector3(cam.transform.position.x, cam.transform.position.y - 0.8f, cam.transform.position.z);
        if(Physics.Raycast(shootPos, cam.transform.forward, out hit, range)) {
            if(hit.transform.gameObject.CompareTag("Cube")) {
                hit.transform.gameObject.GetComponent<TakeDamage>().takeDamage();

                if (hit.rigidbody != null)
                    hit.rigidbody.AddForce(-hit.normal * force);
            }
        }

    }

}
