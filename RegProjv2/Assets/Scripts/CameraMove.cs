using UnityEngine;

public class CameraMove : MonoBehaviour {

    private GameObject player;
    public Vector3 offset;

    private void Update() {
        if(player == null)
            player = GameObject.Find("Player(Clone)");
        else
            transform.position = player.transform.position + offset;
    }

}
