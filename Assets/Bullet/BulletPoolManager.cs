using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class BulletPoolManager
{
	private static PoolPart[] poolsInPollManager;
	private static GameObject parentGO;

	[System.Serializable]
	public struct PoolPart
	{
		public string name;
		public int count;
		public Bullet_PreFab bulletPrefab;
		public BulletPool bulletPool;
	}

	public static void initPool (PoolPart[] pools)
	{
		poolsInPollManager = pools;
		parentGO = new GameObject ();
		parentGO.name = "Bullets";
		for (int i = 0; i < pools.Length; ++i) {
			if (pools [i].bulletPrefab) {
				pools [i].bulletPool = new BulletPool ();
				pools [i].bulletPool.initBullet (pools [i].count, pools [i].bulletPrefab, 
					parentGO.transform);
			}
		}
	}

	public static GameObject getObject (string objectName, Vector3 objectPosition, 
	                                    Quaternion objectRotation)
	{
		GameObject result = null;
		if (poolsInPollManager != null) {
			for (int i = 0; i < poolsInPollManager.Length; ++i) {
				if (string.Compare (poolsInPollManager [i].name, objectName) == 0) {
					result = poolsInPollManager [i].bulletPool.getBulletInstans ().gameObject;
					result.transform.position = objectPosition;
					result.transform.rotation = objectRotation;
					result.SetActive (true);
					return result;
				}
			}
		}
		return result;
	}
}
