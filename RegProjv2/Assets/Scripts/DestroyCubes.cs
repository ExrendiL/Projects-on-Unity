using UnityEngine;

public class DestroyCubes : MonoBehaviour {

    private void Update() {
        if (transform.position.y < -15f)
            Destroy(gameObject);
    }

}
