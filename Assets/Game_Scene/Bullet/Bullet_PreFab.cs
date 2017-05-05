using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet_PreFab : MonoBehaviour
{
	Rigidbody2D bulletRigidBody2D;

	void Awake ()
	{
		bulletRigidBody2D = GetComponent<Rigidbody2D> ();
	}

	void OnBecameInvisible ()
	{
		returnToPool ();
	}

	public void addForseToBullet (Vector2 v2)
	{
		bulletRigidBody2D.AddForce (v2);
	}

	public void returnToPool ()
	{
		gameObject.SetActive (false);
	}
}
