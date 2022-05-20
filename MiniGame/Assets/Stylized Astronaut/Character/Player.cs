using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour 
{
	private Rigidbody rb;
	private Animator anim;
	private float force = 200f;
		
	private void Start ()
	{
		rb = GetComponent<Rigidbody>();
		anim = gameObject.GetComponentInChildren<Animator>();
		anim.SetInteger("AnimationPar", 1);
	}

    private void FixedUpdate()
    {
		if (!InGame.isInGame)
			return;

			if (Input.GetMouseButtonDown(0) && transform.localPosition.y <= 0.5f)
			{
				Jump();
			}
			if (Input.GetTouch(0).phase == TouchPhase.Began && transform.localPosition.y <= 0.5f)
			{
				Jump();
			}
		
    }

	private void Jump()
	{
		if(transform.localPosition.y <= 0.5f)
			rb.AddForce(Vector3.up * force);
	}

}
