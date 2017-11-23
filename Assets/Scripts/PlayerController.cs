using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Animator animator;
    private Rigidbody2D rb;
    public GameObject PlayerCharacter;
    //private SpriteRenderer;


	// Use this for initialization
	void Start ()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
	}

    public float speed;
	
	// Update is called once per frame
	void Update ()
    {
        if (Input.GetKey(KeyCode.RightArrow))
        {
            animator.SetBool("Move", true);
        }

        else
        {
            animator.SetBool("Move", false);
        }

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            //SpriteRenderer.SetBool("Flip", true);
            animator.SetBool("Left", true);
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {

        }
            
	}

    private void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");

        Vector2 movement = new Vector2(moveHorizontal, 0.0f);
        rb.velocity = movement * speed;
    }
}
