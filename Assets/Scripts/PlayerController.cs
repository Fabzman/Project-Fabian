using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Animator animator;
    private Rigidbody2D rb;
    public GameObject PlayerCharacter;
    private SpriteRenderer spriteRenderer;
	public float JumpForce = 150f;
	public float speed;
	public bool jump;


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
            animator.SetBool("Move", true);
            spriteRenderer.flipX = false;
        }

        else
        {
            animator.SetBool("Move", false);
        }

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            spriteRenderer.flipX = true;
            animator.SetBool("Move", true);
        }

		if (Input.GetKeyDown(KeyCode.Space))
		{
			jump = true;
		}
	    
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
