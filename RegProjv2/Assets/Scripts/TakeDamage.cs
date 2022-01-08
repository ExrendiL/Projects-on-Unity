using UnityEngine;

public class TakeDamage : MonoBehaviour {

    private float health = 100f;

    public void takeDamage() {
        health -= 10f;
        if (health <= 0)
            Destroy(gameObject);
    }

}
