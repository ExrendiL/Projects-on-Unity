using UnityEngine;

public class DontDestroy : MonoBehaviour {

    public GameObject music;

    private void Start() {
        GameObject[] objects = GameObject.FindGameObjectsWithTag("Music");
        if (objects.Length == 0) {
            GameObject instObj = Instantiate(music, new Vector2(0, 0), Quaternion.identity) as GameObject;
            DontDestroyOnLoad(instObj);
        }
    }

}
