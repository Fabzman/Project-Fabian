using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour {
    private Rigidbody2D rb;
    private Animator animator;
    public GameObject enemyCharacter;
    private SpriteRenderer spriteRenderer;
    public float speed;

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

    }

    void FixedUpdate()
    {
        //if (spriteRenderer.flipX)
        //{
            rb.AddForce(-transform.right * speed);
            //GetComponent<SpriteRenderer>().flipX = true;
        //}
        //else
        //{
           // rb.AddForce(transform.right * speed);
           // GetComponent<SpriteRenderer>().flipX = false;
        //}
    }
}
