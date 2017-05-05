using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletPool : MonoBehaviour
{
	List<Bullet_PreFab> bullets;
	Transform parentGOInBulletPool;

	public void initBullet (int count, Bullet_PreFab bulletEX, Transform parentGO)
	{
		bullets = new List<Bullet_PreFab> ();
		parentGOInBulletPool = parentGO;
		for (int i = 0; i < count; ++i) {
			addBulletToList (bulletEX, parentGO);
		}
	}

	void addBulletToList (Bullet_PreFab bulletEX, Transform parentGO)
	{
		GameObject tempGO = Instantiate (bulletEX.gameObject);
		tempGO.name = bulletEX.name;
		tempGO.transform.parent = parentGO;
		bullets.Add (tempGO.GetComponent<Bullet_PreFab> ());
		tempGO.SetActive (false);
	}

	public Bullet_PreFab getBulletInstans ()
	{
		for (int i = 0; i < bullets.Count; ++i) {
			if (!bullets [i].gameObject.activeInHierarchy) {
				return bullets [i];
			}
		}
		addBulletToList (bullets [0], parentGOInBulletPool);
		return bullets [bullets.Count - 1];
	}

}
