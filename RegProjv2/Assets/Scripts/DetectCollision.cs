using UnityEngine;

public class DetectCollision : MonoBehaviour {

    public float force = 70f;

    private void OnCollisionEnter(Collision collision) {
        Debug.Log("OnCollisionEnter: Мы прикоснулись к объекту: " + collision.gameObject.name);
        if(collision.gameObject.CompareTag("Cube")) {
            Rigidbody rb = collision.gameObject.GetComponent<Rigidbody>();
            if(rb != null) {
                rb.AddRelativeForce(Vector3.up * force);

                Vector3 forceDir = transform.position - collision.transform.position;
                forceDir.Normalize();

                rb.AddRelativeForce(-forceDir * force);
            }
        }
    }

    private void OnCollisionStay(Collision collision) {
        Debug.Log("OnCollisionStay: Мы прикоснулись к объекту: " + collision.gameObject.name);
    }

    private void OnCollisionExit(Collision collision) {
        Debug.Log("OnCollisionExit: Мы прикоснулись к объекту: " + collision.gameObject.name);
    }

}
