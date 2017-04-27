using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrolObject : MonoBehaviour {
	public float speed = 2f;
	Transform girlPossition;

	// Use this for initialization
	void Start () {
		girlPossition = GetComponent<Transform>();
	}
	
	// Update is called once per frame
	void Update () {
		if(girlPossition.position.x <= 0){
			girlPossition.position += new Vector3(speed * Time.deltaTime, 
			0, 0);
		}
	}
}
