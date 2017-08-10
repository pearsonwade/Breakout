﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour {

	private Vector3 startDir = new Vector3(0,15,0); 	//Initial direction of movement
	private Vector3 movement; 							//Current direction of movement
	private Vector3 ballStart; 							//Initial position of ball



	public Game game;
	public PaddleController paddle;

	public enum axisSwitch { x, y, z}					//Direction change identifier


	//Ball back to starting point
	public void restart () {
		this.transform.position = ballStart;
		movement = startDir;
	}

	//Change ball direction in one axis, change angle of ball off paddle
	public void redirect(axisSwitch axis, float angleChange, bool paddle) {

		if ((int)axis == 0) {

			movement = new Vector3 (-movement.x, movement.y, movement.z);

		} else if ((int)axis == 1) {

			if (paddle) {
				movement = new Vector3 ((movement.x / 2) + angleChange, -(movement.y - 0.5f), movement.z);
			} else {
				movement = new Vector3 (movement.x, -movement.y, movement.z);
			}

		} else if ((int)axis == 2) {
			movement = new Vector3 (movement.x, movement.y, -movement.z);
		}
	}
		
	void Awake() {
		Application.targetFrameRate = 60;
	}

	//Initialization
	void Start () {

		movement = startDir;
		ballStart = new Vector3(this.transform.position.x, this.transform.position.y, this.transform.position.z);

	}

	void Update() {

		//Move the ball
		//GetComponent<Rigidbody>().transform.Translate(movement * Time.deltaTime);
		gameObject.transform.Translate(movement * Time.deltaTime);
	}

	//Collisions between ball and all objects other than bricks
	void OnTriggerEnter(Collider col) {


		Vector3 p = col.ClosestPoint (transform.position);
		Vector3 normal = (p - transform.position);
		normal.z = 0;
		normal.Normalize ();

		movement = movement - 2 * Vector3.Dot (normal, movement) * normal;
		movement.z = 0;

		if (col.gameObject.name == "Paddle") {

			movement.x = movement.x + 3 * paddle.velocity;

			//redirect (axisSwitch.y, 4 * (transform.position.x - col.transform.position.x), true);
		}
		/*



			if (col.gameObject.name == "Paddle") {

				redirect (axisSwitch.y, 4 * (transform.position.x - col.transform.position.x), true);

			} else if (col.gameObject.name == "Left Wall" || col.gameObject.name == "Right Wall") {

				redirect (axisSwitch.x, 0, false);

			} else if (col.gameObject.name == "Top Wall") {

				redirect (axisSwitch.y, 0, false);

			} else if (col.gameObject.name == "Bottom Wall") {

				game.loseLife ();

			}
		//}
*/
	}

}
