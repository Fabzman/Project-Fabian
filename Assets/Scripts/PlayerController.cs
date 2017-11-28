using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Animator animator;
    private Rigidbody2D rb;
    public GameObject PlayerCharacter;
    private SpriteRenderer spriteRenderer;
	public bool jump;
	public GameObject shot;
	public Transform AxeShotSpawn;
	public float JumpForce = 150f;
	public float speed;
	public float fireRate;
	private float nextShot;

	// Use this for initialization
	void Start ()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
	}

    // Update is called once per frame
	void Update ()
    {
        if (Input.GetKey(KeyCode.RightArrow))
        {
			AnimationState ("Move", true);
            spriteRenderer.flipX = false;
        }

        else
        {
            AnimationState ("Move", false);
        }

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            spriteRenderer.flipX = true;
			AnimationState ("Move", true);
        }

		if (Input.GetKeyDown(KeyCode.Space))
		{
			jump = true;
		}

		if (Input.GetKeyDown (KeyCode.E) && Time.time > nextShot) 
		{
			nextShot = Time.time + fireRate;
			AnimationState ("Attack", true);
			GameObject clone = Instantiate (shot, AxeShotSpawn.position, AxeShotSpawn.rotation);
			Destroy (clone, 1.5f);
		} 

		else 
		{
			AnimationState ("Attack", false);
		}
	    
	}

	// We want to run the animation states
	// By obtaining the string name / bool condition in the Animator
	// Then set the animator condition to either false or true.
	void AnimationState(string name, bool condition)
	{
		animator.SetBool (name, condition);
	}

    private void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");

		rb.velocity = new Vector2(moveHorizontal * speed, rb.velocity.y);

		if (jump)
		{
			rb.AddForce (Vector2.up * JumpForce, ForceMode2D.Impulse);
			jump = false;
		}
    }
}
