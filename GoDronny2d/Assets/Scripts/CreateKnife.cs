using UnityEngine;
using System.Collections;

public class CreateKnife : MonoBehaviour {

    public float waitTime = 1f;
    public GameObject knife;
    private bool isSpawn;
    private Coroutine spawn;

    private void Update() {
        if (StartGame.isStart && !isSpawn) {
            spawn = StartCoroutine(spawnKnifes());
            isSpawn = true;
        }
    }

    IEnumerator spawnKnifes() {
        while(true) {
            if (StartGame.isStart) {
                Instantiate(
                    knife,
                    new Vector2(6.17f, Random.Range(-3.27f, -1f)),
                    Quaternion.Euler(new Vector3(0, 0, -45))
                );
            }
            else
                StopCoroutine(spawn);
            yield return new WaitForSeconds(waitTime);
        }
    }

}
