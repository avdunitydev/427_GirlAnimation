using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class OutLineFade : MonoBehaviour {
	Outline oLine;

	// Use this for initialization
	void Start () {
		oLine = GetComponent<Outline>();
	}
	
	// Update is called once per frame
	void Update () {
		oLine.effectColor = new Color(oLine.effectColor.r, 
		oLine.effectColor.g, oLine.effectColor.b, 
		Mathf.PingPong(Time.time, 1f));
	}
}
