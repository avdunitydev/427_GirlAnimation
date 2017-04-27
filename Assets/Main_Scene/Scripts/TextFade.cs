using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class TextFade : MonoBehaviour {
	Text text;

	// Use this for initialization
	void Start () {
		text = GetComponent<Text>();
	}
	
	// Update is called once per frame
	void Update () {
		text.color = new Color (text.color.r, text.color.g, 
		text.color.b, Mathf.PingPong(Time.time / 2.5f, 1f));
	}
}
