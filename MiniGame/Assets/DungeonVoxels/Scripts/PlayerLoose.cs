using UnityEngine;

public class PlayerLoose : MonoBehaviour
{
    public GameObject panelLoose;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Time.timeScale = 0;
            panelLoose.SetActive(true);
        }
    }
}
