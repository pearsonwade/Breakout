using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrickController : MonoBehaviour {

	public BallController ball;
	//public bool hit { get; set; } 

	// Use this for initialization
	void Start () {
		//hit = false;
	}

	// Update is called once per frame
	void Update () {

	}

	void OnCollisionEnter (Collision col) {

		ball.redirect (BallController.axisSwitch.y, 0);
		//gameObject.transform.Translate (0, 0, 5);
		Destroy(gameObject);
	}
}
