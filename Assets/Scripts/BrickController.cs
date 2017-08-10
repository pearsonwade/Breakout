﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrickController : MonoBehaviour {

	//Objects
	public BallController ball;
	public Game game;

	public Vector3 initPos;		//Initial brick position
	private bool again;			
	private bool hit;

	private float collideSpot { get; set; }


	// Use this for initialization
	void Start () {
		initPos = gameObject.transform.position;
		again = false;
		hit = false;
	}

	//Once per frame
	void Update () {
		
		if (hit) {
			gameObject.active = false;
			--game.brickCount;
		}

		hit = false;
	}

	//Collision managemnet, each brick is independent
	//void OnCollisionEnter (Collision col) {
	void OnTriggerEnter(Collider col) {

		//Point on brick that ball collided
		//collideSpot = (col.transform.position.x - gameObject.transform.position.x);

		//Redirect based on collision on top or side
		/*if (Mathf.Abs (collideSpot) <= 1.85f) {
			ball.redirect (BallController.axisSwitch.y, 0, false);
		} else {
			ball.redirect (BallController.axisSwitch.x, 0, false);
		}*/

		//Alternative to destory object, just moves out of sight
	//	GetComponent<Rigidbody>().transform.Translate(0, 0, 5);
		/*gameObject.active = false;
		--game.brickCount;*/

		hit = true;
	}

	//Brick in right position when level is activated 
	void OnEnable() {

		//Every time other than the first
		if (again) {
			gameObject.transform.position = initPos;
		}
	}

	void OnDisable() {
		again = true;
	}
}
