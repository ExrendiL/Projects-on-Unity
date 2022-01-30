using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveDoor1 : MonoBehaviour
{

	private float toPos = -1.96f, toPos1 = 0.5f, speed = 2f;


	private void Update()
	{

		if (Mathf.Abs(transform.position.z) < Mathf.Abs(toPos) && MoveDoor.needToOpen)
		{
			transform.Translate(Vector3.back * speed * Time.deltaTime);
		}

		if (Mathf.Abs(transform.position.z) > Mathf.Abs(toPos1) && !MoveDoor.needToOpen)
		{
			transform.Translate(Vector3.forward * speed * Time.deltaTime);
		}


	}

}