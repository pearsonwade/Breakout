using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game : MonoBehaviour {


	//public GameObject ball;
	//public GameObject paddle;
	//public GameObject cam;
	public WallController tWall;
	public WallController lWall;
	public WallController rWall;
	public WallController bWall;

	public BallController ballCon;
	public PaddleController padCon;


	//private Vector3 ballStart;
	//private Vector3 paddleStart;
	//private int shakes = 0;

	// Use this for initialization
	void Start () {

		//ball = GameObject.Find ("Ball");
		//paddle = GameObject.Find ("Paddle");
		//cam = GameObject.Find ("Main Camera");

		//ballStart = new Vector3(ball.transform.position.x, ball.transform.position.y, ball.transform.position.z);
		//paddleStart = new Vector3 (paddle.transform.position.x, paddle.transform.position.y, paddle.transform.position.z);
		
	}
	
	// Update is called once per frame
	void Update () {
		

		//paddleCheck = ball.transform.position.y < paddle.transform.position.y + 1 && Mathf.Abs (ball.transform.position.x - paddle.transform.position.x) <= paddle.transform.localScale.x / 2;

		if (tWall.hit) {
			ballCon.redirect (BallController.axisSwitch.y);
			tWall.hit = false;
		} else if (lWall.hit || rWall.hit) {
			ballCon.redirect (BallController.axisSwitch.x);
			lWall.hit = false;
			rWall.hit = false;
		} else if (padCon.hit) {
			ballCon.redirect (BallController.axisSwitch.y);
			padCon.hit = false;
		} else if (bWall.hit) {

			// Paddle to original position
			padCon.restart();
			// Ball to original position
			ballCon.restart();

			//TODO: Lose a life

			bWall.hit = false;

		}
			/*
		else if (bottomCheck) {
			ball.transform.position = ballStart;
			paddle.transform.position = paddleStart;
			//shakes = 0;
		}*/
	}
}
