using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveDoor : MonoBehaviour
{


	public static bool needToOpen;


	private float toPos =2.5f, toPos1 = 1f,speed = 2f;
	


	private void Update()
	{

		if (Mathf.Abs(transform.position.z) < Mathf.Abs(toPos) && needToOpen)
		{
			transform.Translate(Vector3.forward * speed * Time.deltaTime);
		}


		if (Mathf.Abs(transform.position.z) > Mathf.Abs(toPos1) && !needToOpen)
		{
			transform.Translate(Vector3.back * speed * Time.deltaTime);
		}



	}

}