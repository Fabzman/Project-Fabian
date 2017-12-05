using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // calls components from inspector
    private Animator animator;
    private Rigidbody2D rb;
    public GameObject PlayerCharacter;
    private SpriteRenderer spriteRenderer;

    // character movement
	public bool jump;
    public float speed;
    public float JumpForce = 150f;

    // used for fire shot spawn and fire rate
    public GameObject shot;
	public Transform AxeShotSpawn;
	public float fireRate;
	private float nextShot;

    // checks to see if character is on ground to prevent jumping infinitely
    public Transform groundCheck;
    public float groundCheckRadius;
    public LayerMask whatIsGrounded;
    private bool grounded;


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
		// moves character to the right
        if (Input.GetKey(KeyCode.RightArrow))
        {
			AnimationState ("Move", true);
            spriteRenderer.flipX = false;
        }

		//makes movement animation stop and idle animation play
        else
        {
            AnimationState ("Move", false);
        }

		// moves character left and flips X on Sprite Renderer making him face the other direction
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            spriteRenderer.flipX = true;
			AnimationState ("Move", true);
        }

		// makes character jump
		if (Input.GetKeyDown(KeyCode.Space) && grounded)
		{
			jump = true;
		}

		// makes character swing axe and fire shot in direction he is facing
		if (Input.GetKeyDown (KeyCode.E) && Time.time > nextShot) 
		{
			nextShot = Time.time + fireRate;
			AnimationState ("Attack", true);
			AnimationState ("Move", false);
			GameObject clone = Instantiate (shot, AxeShotSpawn.position, AxeShotSpawn.rotation);
			Destroy (clone, 1.5f);
		} 

		//makes movement animation stop and idle animation play
		else 
		{
			AnimationState ("Attack", false);
		}
	    
	}

	// We want to run the animation states
	// By obtaining the string name / bool condition in the Animator
	// Then set the animator condition to either false or true.
	public void AnimationState(string name, bool condition)
	{
		animator.SetBool (name, condition);
	}

    private void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");

		rb.velocity = new Vector2(moveHorizontal * speed, rb.velocity.y);

		//makes character jump by adding force multiplied by number in component
		if (jump)
		{
			rb.AddForce (Vector2.up * JumpForce, ForceMode2D.Impulse);
			jump = false;
		}

		//checks to see if player is grounded
        grounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, whatIsGrounded);
    }
}
