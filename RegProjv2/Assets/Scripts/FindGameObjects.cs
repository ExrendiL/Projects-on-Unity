using UnityEngine;

public class FindGameObjects : MonoBehaviour {

    private GameObject obj;

    private void Start() {
        obj = GameObject.Find("/Basic Objects/Main Camera");

        if (obj != null) {
            Debug.Log("Объект был найден");
            // obj.GetComponent<ExampleSome>().enabled = true;
        }
    }

}

