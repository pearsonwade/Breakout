using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrickController : MonoBehaviour {

	//Objects
	public BallController ball;
	public Game game;

	public Vector3 initPos;		//Initial brick position
	private bool again;			

	private float collideSpot { get; set; }

	// Use this for initialization
	void Start () {
		initPos = gameObject.transform.position;
		again = false;
	}

	//Collision managemnet, each brick is independent
	void OnCollisionEnter (Collision col) {

		//Point on brick that ball collided
		collideSpot = (col.transform.position.x - gameObject.transform.position.x);

		//Redirect based on collision on top or side
		if (Mathf.Abs (collideSpot) <= 1.85f) {
			ball.redirect (BallController.axisSwitch.y, 0, false);
		} else {
			ball.redirect (BallController.axisSwitch.x, 0, false);
		}

		//Alternative to destory object, just moves out of sight
		gameObject.transform.Translate (0, 0, 5);
		--game.brickCount;
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
