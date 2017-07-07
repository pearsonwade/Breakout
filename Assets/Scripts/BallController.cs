using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour {

	private Vector3 startDir = new Vector3(2,16,0);
	private Vector3 movement;
	public enum axisSwitch { x, y, z}


	//public GameObject paddle;
	//public GameObject cam;

	private Vector3 ballStart;
	//private Vector3 paddleStart;


	//Ball back to starting point
	public void restart () {
		this.transform.position = ballStart;
		movement = startDir;
	}

	//Change ball direction in one axis
	public void redirect(axisSwitch axis) {
		if ((int)axis == 0) {
			movement = new Vector3 (-movement.x, movement.y, movement.z);
		}
		else if ((int)axis == 1) {
			movement = new Vector3 (movement.x, -movement.y, movement.z);
		}
		else if ((int)axis == 2) {
			movement = new Vector3 (movement.x, movement.y, -movement.z);
		}
	}

	// Use this for initialization
	void Start () {
		
		/*ball = GameObject.Find ("Ball");
		paddle = GameObject.Find ("Paddle");
		cam = GameObject.Find ("Main Camera");*/
		movement = startDir;
		ballStart = new Vector3(this.transform.position.x, this.transform.position.y, this.transform.position.z);

	}
	
	// Update is called once per frame
	void Update () {

		/*if (shakes > 0) {
			if (shakes % 2 == 0) {
				cam.transform.position += new Vector3 (0, 4, -4);
				--shakes;
			} 
			else {
				cam.transform.position += new Vector3 (0, -4, 4);
				--shakes;
			}
		}*/


		//paddleCheck = ball.transform.position.y < paddle.transform.position.y + 1 && Mathf.Abs (ball.transform.position.x - paddle.transform.position.x) <= paddle.transform.localScale.x / 2; //TODO Factor paddle width


		
	/*
		else if (bottomCheck) {
			ball.transform.position = ballStart;
			paddle.transform.position = paddleStart;
			shakes = 0;
		}*/


		//Move the ball
		this.transform.Translate (movement * Time.deltaTime);
	}

}
