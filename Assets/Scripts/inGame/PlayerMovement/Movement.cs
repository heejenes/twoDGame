using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
	Rigidbody2D body;
	float inMoveX;
	float inMoveY;
	bool isMoving = false;
	public float baseMoveSpeed;
	float moveSpeed;
	public Vector2 moveDirection;
//movement^^^^^

	public GameObject autoAttackCol;
	Collider2D autoAttackColComp;
	float autoAttackTS;//time stamp for knowing how long it was held for.
	float inAutoAttack; //input of "l"
	public bool pushingAutoAttack = false;
	public float autoAttackSlowFactor;
	float damage; //final damage after subbing in hold length bonus.
	public float baseDamage; //damage if tapped.
	float autoAttackCharge;
//auto attack^^^^^

	float dashStartTS;
	public bool isDashing = false;
	public float dashLength;
	public float dashSpeed;
//dash for autoattack^^^^

	// Use this for initialization
	void Start () {
		body = GetComponent<Rigidbody2D>();
		autoAttackColComp = autoAttackCol.GetComponent<BoxCollider2D>();
		moveSpeed = baseMoveSpeed;
	}
	
	// Update is called once per frame
	void Update () {
		inMoveX = Input.GetAxis("Horizontal");
		inMoveY = Input.GetAxis("Vertical");
		inAutoAttack = Input.GetAxis("AutoAttack");

		if (inMoveX!=0 | inMoveY!=0){
			isMoving = true;
		}
		else{isMoving = false;}

		if (isMoving){ //moveDirection will be used to know where to point attacks and projectiles.
			moveDirection = new Vector2(inMoveX, inMoveY);
		}

		//wasd and dash
		if (isDashing){
			Debug.Log("is dashing");
			if ((Time.time - dashStartTS)>(dashLength * autoAttackCharge)){
				isDashing = false;
			}
			//TODO: factor in autoAttackCharge for distance and duration of dash.
			//TODO: if autoAttackCharge is below 0.5 seconds, make it a normal attack (small dash, and fast)
			body.velocity = new Vector2(dashSpeed * Time.deltaTime, dashSpeed * Time.deltaTime) * moveDirection;
		}
		else {
			autoAttackColComp.enabled = false;
			if (pushingAutoAttack){
				body.velocity = new Vector2(inMoveX * Time.deltaTime * autoAttackSlowFactor, inMoveY * Time.deltaTime * autoAttackSlowFactor);
			}
			else{
				body.velocity = new Vector2(inMoveX * Time.deltaTime * moveSpeed, inMoveY * Time.deltaTime * moveSpeed);
			}
		}
		/////

		//autoattack trigger
		if (inAutoAttack>0){
			//Debug.Log("charging");
			if (!pushingAutoAttack){
				autoAttackTS = Time.time;
			}
			pushingAutoAttack = true;
		}
		else {
			//Debug.Log("isnt holding autoattack");
			if (pushingAutoAttack){
				//Debug.Log("dashing");
				pushingAutoAttack = false;
				autoAttackColComp.enabled = true;	

				autoAttackCharge = Time.time-autoAttackTS;
				isDashing = true;
				dashStartTS = Time.time;
				damage = baseDamage * autoAttackCharge;	
			}
		}
	}
}

