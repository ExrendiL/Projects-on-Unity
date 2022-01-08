using UnityEngine;
using System.Collections;

public class CreateCubes : MonoBehaviour {

    public GameObject cube;
    private Coroutine spawn;
    static public bool isStarted;

    private void Update() {
        if (isStarted && spawn == null)
            spawn = StartCoroutine(CreateCube());

        if (Input.GetKey(KeyCode.Q))
            StopCoroutine(spawn);
    }

    IEnumerator CreateCube() {
        while(true) {
            Instantiate(cube, new Vector3(Random.Range(-6.5f, 6.5f), 5.5f, Random.Range(-1f, 10f)), Quaternion.identity);
            yield return new WaitForSeconds(3f);
        }
    }

}
