using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SceneTimer : MonoBehaviour {

	public float curentTime = 60;
	private float minTime = 0;
	public float timeDelay = 1f;

	Slider timeSlider;

	// Use this for initialization
	void Start () {
		timeSlider = GetComponent<Slider>();
		timeSlider.interactable = false;
		StartCoroutine(sceneLife(2f));
	}
	
	// Update is called once per frame
	void Update () {
		if (curentTime <= 0){
			UnityEngine.SceneManagement.SceneManager.LoadScene(0);
		}
	}

	IEnumerator sceneLife(float minusTime){
		while(curentTime >= minTime) {
			yield return new WaitForSeconds(timeDelay);
			curentTime -= minusTime;
			timeSlider.value = curentTime;
		}
	}
}
