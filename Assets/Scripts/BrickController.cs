using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrickController : MonoBehaviour {

	public BallController ball;
	public Game game;
	public Vector3 initPos;
	private bool again;

	private float collideSpot { get; set; }

	void Awake() {
		Application.targetFrameRate = 60;
	}
	// Use this for initialization
	void Start () {
		initPos = gameObject.transform.position;
		again = false;
	}

	// Update is called once per frame
	void Update () {
		/*if (game.brickReset) {
			gameObject.transform.position = initPos;
			//game.brickReset = false;
		}*/
	}

	void OnCollisionEnter (Collision col) {

		collideSpot = (col.transform.position.x - gameObject.transform.position.x);
		//Debug.Log ("Collide Spot: " + collideSpot.ToString());

		if (Mathf.Abs (collideSpot) <= 1.85f) {
			ball.redirect (BallController.axisSwitch.y, 0, false);
		} else {
			ball.redirect (BallController.axisSwitch.x, 0, false);
		}

		gameObject.transform.Translate (0, 0, 5);
		--game.brickCount;
		//Destroy(gameObject);
	}

	void OnEnable() {

		if (again) {
			gameObject.transform.position = initPos;
		}

	}

	void OnDisable() {

		again = true;
	}
}
