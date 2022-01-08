using UnityEngine;

public class ExampleSome : MonoBehaviour {

    [SerializeField]
    private float speedMovement = 45.5f;

    public Light obj;

    void Awake() {
        speedMovement = 4f;
        Debug.Log("Awake Function: " + speedMovement);
        //obj.SetActive(false);
    }

    void Start() {
        Debug.Log("Hello");
    }

    private void Update() {
        Debug.Log("Update is called");
    }

    private void FixedUpdate() {
        Debug.Log("Update is called");
    }

    private void OnDestroy() {
        Debug.Log("Destroy");
    }

}
