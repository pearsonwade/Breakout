using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour {

	private Vector3 startDir = new Vector3(2,16,0);
	private Vector3 movement;
	private Vector3 ballStart;

	public enum axisSwitch { x, y, z}


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
		
		movement = startDir;
		ballStart = new Vector3(this.transform.position.x, this.transform.position.y, this.transform.position.z);

	}
	
	// Update is called once per frame
	void Update () {

		//Move the ball
		this.transform.Translate (movement * Time.deltaTime);
	}

}
