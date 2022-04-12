using UnityEngine;

public class LoadGame : MonoBehaviour
{
    public GameObject player;
    public void loadPlayer()
    {
        PlayerData data = SaveSystem.loadPlayer();
        Vector3 pos = new Vector3(data.position[0], data.position[1], data.position[2]);
        player.transform.position = pos;
        player.GetComponent<PlayerHealth>().health = data.health;
        player.GetComponent<PlayerHealth>().setHealthBar();
    }
}
