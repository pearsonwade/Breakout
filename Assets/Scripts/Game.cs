using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class Game : MonoBehaviour {

	public WallController tWall;
	public WallController lWall;
	public WallController rWall;
	public WallController bWall;

	public BallController ballCon;
	public PaddleController padCon;

	public Image gameOver;



	private int life;
	public Text lifeText;

	public bool brickReset { get; set; }
	public int brickCount;
	int initBricks;

	// Use this for initialization
	void Start () {
		life = 2;
		lifeText.text = "Lives: " + life.ToString ();
		brickReset = false;
		initBricks = brickCount;
	}
	
	// Update is called once per frame
	void Update () {

		if (Input.GetKeyDown("space") && (life < 0 || brickCount <= 0)) {
			brickReset = false;
			life = 2;
			brickCount = initBricks;
			lifeText.text = "Lives: " + life.ToString ();
			gameOver.gameObject.SetActive (false);
			// Paddle to original position
			padCon.restart ();
			// Ball to original position
			ballCon.restart ();
			Time.timeScale = 1;

		} else if (life < 0 || brickCount <= 0) {
			
			gameOver.gameObject.SetActive (true);
			Time.timeScale = 0;
			brickReset = true;

		}
			
		//Collisions: Walls(TOP - LEFT - RIGHT - BOTTOM), Paddle
		if (tWall.hit) {
			
			ballCon.redirect (BallController.axisSwitch.y, 0);
			tWall.hit = false;

		} else if (lWall.hit || rWall.hit) {
			
			ballCon.redirect (BallController.axisSwitch.x, 0);
			lWall.hit = false;
			rWall.hit = false;

		} else if (padCon.hit) {
			
			ballCon.redirect (BallController.axisSwitch.y, padCon.collideLoc);
			padCon.hit = false;

		} else if (bWall.hit) {

			// Paddle to original position
			padCon.restart ();
			// Ball to original position
			ballCon.restart ();

			//Lose a life
			--life;

			if (life >= 0) {
				lifeText.text = "Lives: " + life.ToString ();
			}

			bWall.hit = false;

		}

	}
}
