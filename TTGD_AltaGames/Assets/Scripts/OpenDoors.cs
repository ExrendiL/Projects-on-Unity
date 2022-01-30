using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenDoors : MonoBehaviour
{
	private void OnTriggerEnter(Collider other)
	{

        if (other.CompareTag("TriggerDoors"))
			MoveDoor.needToOpen = true;
		Debug.Log(MoveDoor.needToOpen);
	}
	private void OnTriggerExit(Collider other)
	{

		if (other.CompareTag("TriggerDoors"))
			MoveDoor.needToOpen = false;
		Debug.Log(MoveDoor.needToOpen);
	}

}
