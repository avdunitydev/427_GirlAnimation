using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainButton : MonoBehaviour
{
	public float speed = 5f;
	RectTransform rect;


	void Start ()
	{
		rect = GetComponent<RectTransform> ();
	}

	void Update ()
	{
		if (rect.offsetMin.y <= 0) {
			rect.offsetMin += new Vector2 (rect.offsetMin.x, speed);
		}
	}

	void OnMouseDown ()
	{
		UnityEngine.SceneManagement.SceneManager.LoadScene (1);
	}
}
