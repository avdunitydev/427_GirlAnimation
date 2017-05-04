using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletNonActive : MonoBehaviour
{

	void OnCollisionEnter2D (Collision2D other)
	{
		if (other.transform.name == "Bullet" || other.transform.name == "BulletRed") {
			other.gameObject.SetActive (false);
		}
	}
}
