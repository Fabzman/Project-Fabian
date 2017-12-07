using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // Calls components from inspector
    private Animator animator;
    private Rigidbody2D rb;
    public GameObject PlayerCharacter;
    private SpriteRenderer spriteRenderer;
    public GameObject EnemyCharacter;
    public GameObject PlayerContainer;

    // Character movement
    public bool jump;
    public float speed;
    public float JumpForce = 150f;

    // Used for fire shot spawn and fire rate
    public GameObject shot;
	public Transform AxeShotSpawn;
	public float fireRate;
	private float nextShot;

    // Checks to see if character is on ground to prevent jumping infinitely
    public Transform groundCheck;
    public float groundCheckRadius;
    public LayerMask whatIsGrounded;
    private bool grounded;


	public PlayerDeath playerDeath;

    // Use this for initialization
    void Start ()
    {
        PlayerCharacter = GameObject.FindGameObjectWithTag("Player");
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
	}

    // Update is called once per frame
	void Update ()
    {
		// Moves character to the right and plays movement animation when key held
        if (Input.GetKey(KeyCode.RightArrow))
        {
			AnimationState ("Move", true);
            spriteRenderer.flipX = false;
        }

		// Makes movement animation stop and idle animation play
        else
        {
            AnimationState ("Move", false);
        }

		// Moves character left when key held and flips X on Sprite Renderer making him face the other direction
        // Also makes movement animation play
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            spriteRenderer.flipX = true;
			AnimationState ("Move", true);
        }

		// Makes character jump when key pressed
		if (Input.GetKeyDown(KeyCode.Space) && grounded)
		{
			jump = true;
		}

		// Makes character swing axe (Animation) and fire shot prefab in direction he is facing when key pressed
		if (Input.GetKeyDown (KeyCode.E) && Time.time > nextShot) 
		{
			nextShot = Time.time + fireRate;
			AnimationState ("Attack", true);
			AnimationState ("Move", false);
            if (AxeShotSpawn == null)
            {
                // Code will return if axe shot spawner is null to prevent firing after death
                return;
            }

            if (AxeShotSpawn != null)
            {
                // Axe shot will instantiate if it is not null and destroy the prefab after 1.5 seconds
                GameObject clone = Instantiate(shot, AxeShotSpawn.position, AxeShotSpawn.rotation);
                Destroy(clone, 1.5f);
            }
		} 

		// Makes movement animation stop and idle animation play but is not working properly
		else 
		{
			AnimationState ("Attack", false);
		}


		if (playerDeath.HasDied == true) 
		{
			speed = 0;
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

		// Makes character jump by adding force multiplied by number in component
		if (jump)
		{
			rb.AddForce (Vector2.up * JumpForce, ForceMode2D.Impulse);
			jump = false;
		}

		// Checks to see if player is grounded
        // If character is grounded he will be unable to jump again
        grounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, whatIsGrounded);
    }
}
