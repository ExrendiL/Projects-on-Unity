using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPlayer : MonoBehaviour
{
    [SerializeField] private GameObject restart_btn;
    private void Update()
    {
        if (GameObject.Find("Player") == null)
        {
            restart_btn.SetActive(true);
            CheckController.readyToMove = false;
            MoveDoor.needToOpen = false;
        }
    }
}
