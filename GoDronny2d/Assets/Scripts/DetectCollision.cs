using UnityEngine;

public class DetectCollision : MonoBehaviour {

    public Color deathColor;
    private SpriteRenderer sr;

    public GameObject explosion, panelLose;
    private AudioSource audioLose;

    private void Awake() {
        sr = GetComponent<SpriteRenderer>();
        audioLose = GetComponent<AudioSource>();
    }

    private void OnCollisionEnter2D(Collision2D collision) {
        if(collision.gameObject.CompareTag("Knife")) {
            StartGame.isStart = false;
            Destroy(collision.transform.parent.gameObject);
            sr.color = deathColor;

            ContactPoint2D contact = collision.contacts[0];
            Vector3 pos = contact.point;
            GameObject exp = Instantiate(explosion, pos, Quaternion.identity) as GameObject;
            Destroy(exp, 1f);
            audioLose.Play();

            panelLose.SetActive(true);
        }
    }

}
