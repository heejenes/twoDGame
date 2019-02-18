using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoad : MonoBehaviour {
	public void loadLevel(int level){
		Debug.Log("button presed");
		SceneManager.LoadScene(level); //loads scene with index of 1 in heiarchy
	}
}
