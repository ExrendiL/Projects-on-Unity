using UnityEngine;

public class StartGame : MonoBehaviour {

    private void OnTriggerExit(Collider other) {
        if(other.gameObject.CompareTag("Player"))
            CreateCubes.isStarted = true;
    }

}
