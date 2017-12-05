using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyWhenHit : MonoBehaviour {

	private Animator animator;
	public bool HasDied;
	private float timer;


	// Use this for initialization
	void Start () 
	{
		// Set the timer amount once it's connected with the trigger.
		timer = 0.1f;
		animator = GetComponent <Animator>();
		HasDied = false;
	}
	
	// Update is called once per frame
	void Update ()
	{
		// If our enemy has died = true.
		if (HasDied) 
		{
			// Countdown the timer to when his body is removed.
			timer -= Time.deltaTime;

			// If the timer reaches 0, remove the body
			if (timer <= 0) 
			{
				Destroy (gameObject);
			}
		}
	}

    private void OnTriggerEnter2D(Collider2D other)
	{
		if (other.tag == "Boundary") 
		{
			return;
		}

		if (other.tag == "Shot") 
		{
			animator.Play ("Enemy_Explode");
			HasDied = true;
		}
	}

	public void AnimationState(string name, bool condition)
	{
		animator.SetBool (name, condition);
	}
}
