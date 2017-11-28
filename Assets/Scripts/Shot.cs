using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shot : MonoBehaviour 
{
	private GameObject player;
	private Rigidbody2D rb;
	public float speed;
	public SpriteRenderer spriteRenderer;

	// Use this for initialization
	void Start () 
	{
		player = GameObject.FindGameObjectWithTag ("Player");
		rb = GetComponent<Rigidbody2D>();
		spriteRenderer = player.GetComponent<SpriteRenderer> ();
	}
		
	// Update is called once per frame
	void FixedUpdate () 
	{
		if (spriteRenderer.flipX) 
		{
			rb.AddForce (-transform.right * speed);
			GetComponent<SpriteRenderer> ().flipX = true;
		} 
		else 
		{
			rb.AddForce (transform.right * speed);
			GetComponent<SpriteRenderer> ().flipX = false;
		}

	}


}
