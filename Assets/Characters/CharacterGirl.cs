using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterGirl : MonoBehaviour
{
	public float speed = 1;
	public Transform sensGround;
	public LayerMask layerGround;
	SpriteRenderer sprr;
	Rigidbody2D girlCharacter;
	Animator anim;
	float move;
	bool isRight = true;
	public bool isGround = false;


	// Use this for initialization
	void Start ()
	{
		sprr = GetComponent<SpriteRenderer> ();
		girlCharacter = GetComponent<Rigidbody2D> ();
		anim = GetComponent<Animator> ();

	}
	
	// Update is called once per frame
	void Update ()
	{
		
	}

	void FixedUpdate ()
	{
		isGround = Physics2D.OverlapCircle (sensGround.position, 0.2f, layerGround);
		anim.SetBool ("isGround", isGround);
		anim.SetFloat ("ySpeed", girlCharacter.velocity.y);

		move = Input.GetAxis ("Horizontal");
		anim.SetFloat ("xSpeed", Mathf.Abs (move));

		girlCharacter.velocity = new Vector2 (move * speed, girlCharacter.velocity.y);
		if (move > 0 && !isRight) {
			sprr.flipX = false;
			isRight = true;
		} else if (move < 0 && isRight) {
			sprr.flipX = true;
			isRight = false;
		}

		if (isGround && (Input.GetAxis ("Vertical") > 0)) { 
			anim.SetBool ("isGround", false);
			girlCharacter.AddForce (new Vector2 (0, 700));
		}
	}
}
