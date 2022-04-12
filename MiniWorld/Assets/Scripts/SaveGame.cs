using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveGame : MonoBehaviour
{
    public GameObject player;
    public void savePlayer()
    {
        float health = player.GetComponent<PlayerHealth>().health;
        float positionX = player.transform.position.x;
        float positionY = player.transform.position.y;
        float positionZ = player.transform.position.z;
        SaveSystem.saveData(health, positionX, positionY, positionZ);
    }
}
