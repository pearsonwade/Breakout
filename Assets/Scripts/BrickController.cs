using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrickController : MonoBehaviour {

	public BallController ball;
	public Game game;
	private Vector3 initPos;

	// Use this for initialization
	void Start () {
		initPos = gameObject.transform.position;	
	}

	// Update is called once per frame
	void Update () {
		if (game.brickReset) {
			gameObject.transform.position = initPos;
		}
	}

	void OnCollisionEnter (Collision col) {

		ball.redirect (BallController.axisSwitch.y, 0);
		gameObject.transform.Translate (0, 0, 5);
		--game.brickCount;
		//Destroy(gameObject);
	}
}
