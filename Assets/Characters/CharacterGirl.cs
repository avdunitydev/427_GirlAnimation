using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterGirl : MonoBehaviour
{
	public float speed;
	public Transform sensGround;
	public LayerMask layerGround;
	public Transform bullet_PF, bulletRed_PF;
	public int fpc_HP;

	SpriteRenderer sprr;
	Rigidbody2D girlCharacter;
	Animator anim;
	GameObject fire;

	float move;
	bool isRight = true;
	bool isGround = false;

	void Awake ()
	{
		
	}

	// Use this for initialization
	void Start ()
	{
		speed = 6f;
		fpc_HP = 10;
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

		fireFPC ();
	}

	// Update is called once per frame
	void Update ()
	{
	}

	void fireDirection ()
	{
		if (isRight) {
			fire.GetComponent<Bullet_PreFab> ().addForseToBullet (new Vector2 (500, 0));
		} else {
			fire.GetComponent<Bullet_PreFab> ().addForseToBullet (new Vector2 (-500, 0));
		}
	}

	void fireFPC ()
	{
		if (Input.GetKeyDown (KeyCode.RightControl)) {
			if (Input.GetKey (KeyCode.LeftShift)) {
				fire = BulletPoolManager.getObject (bulletRed_PF.name, new Vector3 (transform.position.x + 0.5f, transform.position.y - 0.5f, transform.position.z), 
					Quaternion.identity);
				fireDirection ();
			} else {
				fire = BulletPoolManager.getObject (bullet_PF.name, transform.position, Quaternion.identity);
				fireDirection ();
			}
		}
	}

	void OnCollisionEnter2D (Collision2D other)
	{
		if (fpc_HP <= 0) {
			transform.position = new Vector3 (21, 0, 0); 
			fpc_HP = 10;
		}
		if (other.transform.name == "BulletRed") {
			--fpc_HP;
			print ("CHARACTER HEALTH = " + fpc_HP);  
			other.gameObject.SetActive (false);
		}
	}
}
