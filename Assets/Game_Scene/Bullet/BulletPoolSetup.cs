using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletPoolSetup : MonoBehaviour
{
	[SerializeField]
	private BulletPoolManager.PoolPart[] pools;

	void OnValidate ()
	{
		for (int i = 0; i < pools.Length; ++i) {
			pools [i].name = pools [i].bulletPrefab.name;
		}
	}

	void Awake ()
	{
		BulletPoolManager.initPool (pools);
	}
}
