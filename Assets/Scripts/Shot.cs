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
	private float flip;

	// Use this for initialization
	void Start () 
	{
		player = GameObject.FindGameObjectWithTag ("Player");
		rb = GetComponent<Rigidbody2D>();
		spriteRenderer = player.GetComponent<SpriteRenderer> ();
	
		if (spriteRenderer.flipX)
		{
			flip = -1f;
			GetComponent<SpriteRenderer> ().flipX = true;
		}
		else
		{
			flip = 1f;
			GetComponent<SpriteRenderer> ().flipX = false;
		}
	}
		
	// Update is called once per frame
	void FixedUpdate () 
	{
        // If flip X on sprite renderer is true the projectile will travel towards the left according to the value in the float component
		rb.AddForce (flip * transform.right * speed);

        // If flip X on sprite renderer is false the projectile will travel in the opposite direction according to the value in the float component
	}
}
