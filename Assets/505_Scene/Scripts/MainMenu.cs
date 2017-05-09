using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour {
public void runScene1(){
	SceneManager.LoadScene(1);
}
public void runScene2(){
	SceneManager.LoadScene(2);
}
public void runScene3(){
	SceneManager.LoadScene(3);
}
public void exitApp(){
	Application.Quit();
}

}
