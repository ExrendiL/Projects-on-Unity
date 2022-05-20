using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartGame : MonoBehaviour
{
    public GameObject spawnCubes;

    public void PlayGame()
    {
        spawnCubes.GetComponent<SpawnCubes>().enabled = true;
        InGame.isInGame = true;
        gameObject.SetActive(false);
    }

}
