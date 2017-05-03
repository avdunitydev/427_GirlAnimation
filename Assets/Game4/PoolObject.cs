using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoolObject : MonoBehaviour
{
    Rigidbody2D rigidbody2D_obj;

    void Awake()
    {
        rigidbody2D_obj = GetComponent<Rigidbody2D>();
    }

    void OnBecameInvisible()
    {
        ReturnToPool();
    }

    public void AddForseObject(Vector2 forge)
    {
        rigidbody2D_obj.AddForce(forge);
    }

    public void ReturnToPool()
    {
        gameObject.SetActive(false);
    }
}
