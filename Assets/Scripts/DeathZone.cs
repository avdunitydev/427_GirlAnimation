using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathZone : MonoBehaviour
{

	// Use this for initialization
	void Start ()
	{
		
	}
	
	// Update is called once per frame
	void Update ()
	{
		
	}

	void OnTriggerEnter2D (Collider2D other)
	{
		//other.gameObject.transform.position = new Vector3 (-5f, 14f, 0f);
		other.transform.position = new Vector3 (-5f, 14f, 0f);
	}

	//	void OnCollisionEnter2D (Collision2D other)
	//	{
	//		other.gameObject.transform.position = new Vector3 (-5f, 14f, 0f);
	//	}

}
