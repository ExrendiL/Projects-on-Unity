using UnityEngine;

public class MoveBg : MonoBehaviour {

    public float speed = 5f;

    private void Update() {
        if (StartGame.isStart) {
            transform.Translate(Vector2.left * speed * Time.deltaTime);
        }
    }

}
