using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class PoolManager
{
	private static PoolPart[] pools;
	private static GameObject objectsParent;

	[System.Serializable]
	public struct PoolPart
	{
		public string name;
		public PoolObject perfab;
		public int count;
		public ObjectPooling pool;
	}

	public static void Inizialize (PoolPart[] newPools)
	{
		pools = newPools;
		objectsParent = new GameObject ();
		objectsParent.name = "Pool";
		for (int i = 0; i < pools.Length; ++i) {
			if (pools [i].perfab) {
				pools [i].pool = new ObjectPooling ();
				pools [i].pool.Inizialize (pools [i].count, pools [i].perfab, 
					objectsParent.transform);
			}
		}
	}

   
	public static GameObject GetObject (string name, Vector3 position, Quaternion rotation)
	{
		GameObject result = null;
		if (pools != null) {
			for (int i = 0; i < pools.Length; ++i) {
				if (string.Compare (pools [i].name, name) == 0) {
					result = pools [i].pool.GetObject ().gameObject;
					result.transform.position = position;
					result.transform.rotation = rotation;
					result.SetActive (true);
					return result;
				}
			}
		}
		return result; 
	}
}
