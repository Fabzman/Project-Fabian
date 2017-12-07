using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shot : MonoBehaviour 
{
	private GameObject player;
	private Rigidbody2D rb;
	public float speed;
	public SpriteRenderer spriteRenderer;
    public GameObject enemyCharacter;

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
        // If flip X on sprite renderer is true the projectile will travel towards the left according to the value in the float component
		if (spriteRenderer.flipX) 
		{
			rb.AddForce (-transform.right * speed);
			GetComponent<SpriteRenderer> ().flipX = true;
		} 

        // If flip X on sprite renderer is false the projectile will travel in the opposite direction according to the value in the float component
		else 
		{
			rb.AddForce (transform.right * speed);
			GetComponent<SpriteRenderer> ().flipX = false;
		}
	}
}
