using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SunSystemRun : MonoBehaviour {
	Animator anim;
	public bool flagTest = false;

	
	// Use this for initialization
	void Start () {
		anim = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKeyUp(KeyCode.Space)){
		anim.SetBool("orbit1", !anim.GetBool("orbit1"));
		anim.SetBool("orbit2", !anim.GetBool("orbit2"));
		anim.SetBool("orbit3", !anim.GetBool("orbit3"));
		anim.SetBool("orbit4", !anim.GetBool("orbit4"));
		flagTest = anim.GetBool("orbit1");
		}
	}
}
