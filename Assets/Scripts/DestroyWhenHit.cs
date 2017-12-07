using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyWhenHit : MonoBehaviour {

	private Animator animator;
	public bool HasDied;
	private float timer;
    public int scoreValue;
    public TextScripting textScripting;


	// Use this for initialization
	void Start () 
	{
        // Finds script for score
        GameObject textScritpingObject = GameObject.FindWithTag("Score");
        if (textScritpingObject != null)
        {
            textScripting = textScritpingObject.GetComponent<TextScripting>();
        }

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
                // Adds score for dead enemy and destroys his prefab
                textScripting.AddScore (scoreValue);
				Destroy (gameObject);
			}
		}
	}

    private void OnTriggerEnter2D(Collider2D other)
	{
        // If enemy hits boundary does not play enemy explode animation
		if (other.tag == "Boundary") 
		{
			return;
		}

		if (other.tag == "Shot") 
		{
            // If enemy hits shot plays enemy explode animation
			animator.Play ("Enemy_Explode");
			HasDied = true;
		}
	}

	public void AnimationState(string name, bool condition)
	{
		animator.SetBool (name, condition);
	}
}
