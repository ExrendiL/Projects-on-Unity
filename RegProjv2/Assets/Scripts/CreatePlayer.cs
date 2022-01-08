using UnityEngine;

public class CreatePlayer : MonoBehaviour {

    public GameObject player;
    private bool isCreated;
    private GameObject createdObject;

    private void Start() {
        createPlayer();
    }

    private void Update() {
        if (Input.GetKey(KeyCode.P) && !isCreated)
            createPlayer();

        if(createdObject != null) {
            Debug.Log("Объект был создан");
            //Destroy(createdObject, 2f);
        }
    }

    void createPlayer() {
        createdObject = Instantiate(
            player,
            new Vector3(0, 0, 0),
            Quaternion.Euler(new Vector3(0, 0, 0))
        ) as GameObject;
        isCreated = true;
    }

}
