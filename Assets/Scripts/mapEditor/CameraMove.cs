using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour {

	float moveX;
	float moveY;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		moveX = Input.GetAxis("Horizontal");
		moveY = Input.GetAxis("Vertical");
		transform.position += new Vector3(moveX, moveY, 0);
		
	}
}
