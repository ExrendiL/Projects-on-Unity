using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {

	private Animator anim;
	//private CharacterController controller;
	private Rigidbody rb;
	private AudioSource audio;
	public AudioSource jumpAudio;

	public float speed = 600.0f, juumpForce = 450f;
	public float turnSpeed = 400.0f;
	private float moveDirection;

	void Start ()
	{
		//controller = GetComponent <CharacterController>();
		rb = GetComponent<Rigidbody>();
		audio = GetComponent<AudioSource>();
		anim = gameObject.GetComponentInChildren<Animator>();
	}

	void Update()
	{
		if (!PlayerHealth.death)
		{
			if (Input.GetKey("w"))
			{
				anim.SetInteger("AnimationPar", 1);
				if (!audio.isPlaying)
				{
					audio.Play();
				}
				
			}
			else
			{
				anim.SetInteger("AnimationPar", 0);
				if (audio.isPlaying)
				{
					audio.Pause();
				}
			}
			if (rb.velocity.y == 0)
			{
				anim.SetBool("isJump", false);
			}
			if (Input.GetKeyDown(KeyCode.Space) && rb.velocity.y == 0)
			{
				rb.AddForce(Vector3.up * juumpForce);
				anim.SetTrigger("Jumping");
				anim.SetBool("isJump", true);
				jumpAudio.Play();
			}

			moveDirection = Input.GetAxis("Vertical") * speed * Time.deltaTime;

			rb.MovePosition(transform.position + transform.forward * moveDirection);
			float turn = Input.GetAxis("Horizontal");
			transform.Rotate(0, turn * turnSpeed * Time.deltaTime, 0);

		}
	}
}
