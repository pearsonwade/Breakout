using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour {

	private Vector3 startDir = new Vector3(0,15,0);
	private Vector3 movement;
	private Vector3 ballStart;

	public Game game;

	public enum axisSwitch { x, y, z}


	//Ball back to starting point
	public void restart () {
		this.transform.position = ballStart;
		movement = startDir;
	}

	//Change ball direction in one axis, change anlge of ball off paddle, may split into two functions later
	public void redirect(axisSwitch axis, float angleChange, bool paddle) {
		if ((int)axis == 0) {
			movement = new Vector3 (-movement.x, movement.y, movement.z);
		}
		else if ((int)axis == 1) {
			if (paddle) {
				movement = new Vector3 ((movement.x / 2) + angleChange, -(movement.y - 0.5f), movement.z);
			} else {
				movement = new Vector3 (movement.x, -movement.y, movement.z);
			}
		}
		else if ((int)axis == 2) {
			movement = new Vector3 (movement.x, movement.y, -movement.z);
		}
	}

	// Use this for initialization
	void Start () {
		
		movement = startDir;
		ballStart = new Vector3(this.transform.position.x, this.transform.position.y, this.transform.position.z);

	}
	
	// Update is called once per frame
	void Update () {

		//Move the ball
		this.transform.Translate (movement * Time.deltaTime);
	}

	void OnCollisionEnter (Collision col) {

		if (col.gameObject.name == "Paddle") { //Paddle

			//Debug.Log ("Ball collided with paddle");
			redirect(axisSwitch.y, 4 * (transform.position.x - col.transform.position.x), true);

		} else if (col.gameObject.name == "Left Wall" || col.gameObject.name == "Right Wall") { //L&R Walls

			//Debug.Log ("Ball collided with Side Wall");
			redirect(axisSwitch.x, 0, false);

		} else if (col.gameObject.name == "Top Wall") { //Top Wall

			//Debug.Log ("Ball collided with Top");
			redirect(axisSwitch.y, 0, false);

		} else if (col.gameObject.name == "Bottom Wall") { //Bottom Wall

			//Debug.Log ("Ball collided with bottom");
			game.loseLife ();

		}
	}

}
