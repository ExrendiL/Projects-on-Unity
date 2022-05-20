using System.Collections;
using UnityEngine;

public class SpawnCubes : MonoBehaviour
{
    public GameObject cube;
    public int minCubes = 1, maxCubes = 5;

   private void Start()
    {
        StartCoroutine(spawn());
    }

    IEnumerator spawn()
    {
        while (true)
        {
            GameObject spawnCube = null;
            Vector3 pos = transform.position;
            int howManyCubes = Random.Range(minCubes, maxCubes);
            for (int i =0; i<howManyCubes; i++)
            {
                if (i > 0)
                {
                    pos = new Vector3(
                        spawnCube.transform.position.x,
                        spawnCube.transform.position.y,
                        spawnCube.transform.position.z + 0.5f
                        );
                }
                spawnCube = Instantiate(cube, pos, Quaternion.identity) as GameObject;
            }
            float wait = 4.2f;
            switch (howManyCubes)
            {
                case 1: wait = 2f; break;
                case 2: wait = 2.8f; break;
                case 3: wait = 3.3f; break;
                case 4: wait = 3.7f; break;
            }
            yield return new WaitForSeconds(wait);
        }
    }
}
