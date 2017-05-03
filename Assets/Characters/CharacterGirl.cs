using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterGirl : MonoBehaviour
{
	public float speed = 1f;
	public Transform sensGround;
	public LayerMask layerGround;
	SpriteRenderer sprr;
	Rigidbody2D girlCharacter;
	Animator anim;
	float move;
	public bool isRight = true;
	public bool isGround = false;
	public float _xSpeed;

	public Transform bullet_PF, bulletRed_PF;


	// Use this for initialization
	void Start ()
	{
		sprr = GetComponent<SpriteRenderer> ();
		girlCharacter = GetComponent<Rigidbody2D> ();
		anim = GetComponent<Animator> ();

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
			girlCharacter.AddForce (new Vector2 (0, 800));
		}

		if (Input.GetKeyDown (KeyCode.RightControl)) {
			GameObject fire;
			if (Input.GetKey (KeyCode.LeftShift)) {
				fire = BulletPoolManager.getObject (bulletRed_PF.name, new Vector3 (transform.position.x + 0.5f, transform.position.y - 0.5f, transform.position.z), 
					Quaternion.identity);
			} else {
				fire = BulletPoolManager.getObject (bullet_PF.name, transform.position, Quaternion.identity);
			}

			if (isRight) {
				fire.GetComponent<Bullet_PreFab> ().addForseToBullet (new Vector2 (500, 0));
			} else {
				fire.GetComponent<Bullet_PreFab> ().addForseToBullet (new Vector2 (-500, 0));
			}
		}

	}

	// Update is called once per frame
	void Update ()
	{
		_xSpeed = Mathf.Abs (move);
	}
}
