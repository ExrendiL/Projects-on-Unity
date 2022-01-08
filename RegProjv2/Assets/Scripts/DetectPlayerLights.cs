using UnityEngine;

public class DetectPlayerLights : MonoBehaviour {

    public Light mainLight, pointLight;

    private void OnTriggerEnter(Collider other) {
        if(other.gameObject.CompareTag("Player")) {
            mainLight.intensity = 0.2f;
            mainLight.color = new Color(181f/255f, 74f / 255f, 104f / 255f);
        }
    }

    private void OnTriggerStay(Collider other) {
        if (other.gameObject.CompareTag("Player")) {
            if(Input.GetKeyUp(KeyCode.E))
                pointLight.enabled = !pointLight.enabled;
        }
    }

    private void OnTriggerExit(Collider other) {
        if (other.gameObject.CompareTag("Player")) {
            mainLight.intensity = 1f;
            mainLight.color = Color.white;
        }
    }

}
