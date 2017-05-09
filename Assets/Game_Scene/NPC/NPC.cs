using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC : MonoBehaviour
{
	public float speed;
	public Transform sensGround;
	public Transform sensL;
	public Transform sensR;
	public LayerMask layerGround;
	public Transform bulletRed_PF;
	public int npc_HP;

	Rigidbody2D npc;
	SpriteRenderer sprr;
	Animator anim;
	GameObject fire;
	Transform fpcCamera;

	float move;
	bool isRight;
	public bool isSensG;
	public bool isSensL;
	public bool isSensR;

	float timer;

	void Awake ()
	{
		speed = 1.6f;
		npc_HP = 3;
		isRight = true;
		isSensG = false;
		isSensL = false;
		isSensR = false;
	}

	// Use this for initialization
	void Start ()
	{
		sprr = GetComponent<SpriteRenderer> ();
		npc = GetComponent<Rigidbody2D> ();
		anim = GetComponent<Animator> ();

		fpcCamera = Camera.main.transform.parent;


	}

	void FixedUpdate ()
	{
		checkGround ();
		moveNPC ();
		anim.SetFloat ("ySpeed", npc.velocity.y);
		fireNPC ();
	}

	// Update is called once per frame
	void Update ()
	{
		timer += Time.deltaTime;
	}

	void checkGround ()
	{
		isSensG = Physics2D.OverlapCircle (sensGround.position, 0.2f, layerGround);
		anim.SetBool ("isGround", isSensG);
		isSensL = Physics2D.OverlapCapsule (sensL.position, new Vector2 (0.1f, 1.8f), new CapsuleDirection2D (), 0, layerGround);
		isSensR = Physics2D.OverlapCapsule (sensR.position, new Vector2 (0.1f, 1.8f), new CapsuleDirection2D (), 0, layerGround);
	}

	void moveNPC ()
	{
		if (isRight && !isSensR) {
			move = -1f * speed;           
		} else if (!isRight && !isSensL) {
			move = 1f * speed;  
		}

		anim.SetFloat ("xSpeed", Mathf.Abs (move));

		npc.velocity = new Vector2 (move * speed, npc.velocity.y);

		if (move > 0 && !isRight) {
			sprr.flipX = false;
			isRight = true;
		} else if (move < 0 && isRight) {
			sprr.flipX = true;
			isRight = false;
		}
	}

	void fireNPC ()
	{
		if (timer > 0.5 && Vector3.Distance (transform.position, fpcCamera.position) < 7
		    && Mathf.Abs (transform.position.y - fpcCamera.position.y) < 0.5f) {
			timer = 0;
			GameObject fireNPC;         
			if (isRight && transform.position.x - fpcCamera.position.x < 0) {
				fireNPC = BulletPoolManager.getObject (bulletRed_PF.name, transform.position, Quaternion.identity);   
				fireNPC.GetComponent<Bullet_PreFab> ().addForseToBullet (new Vector2 (500, 0));
			} else if (!isRight && transform.position.x - fpcCamera.position.x > 0) {
				fireNPC = BulletPoolManager.getObject (bulletRed_PF.name, transform.position, Quaternion.identity);   
				fireNPC.GetComponent<Bullet_PreFab> ().addForseToBullet (new Vector2 (-500, 0));
			}
		}
	}

	void OnCollisionEnter2D (Collision2D other)
	{
		if (npc_HP <= 0) {
			transform.position = new Vector3 (21, 0, 0); 
			npc_HP = 3;
		}
		if (other.transform.name == "Bullet") {
			--npc_HP;
			print ("ENEMY HEALTH = " + npc_HP);  
			other.gameObject.SetActive (false);
		}
	}
}
