using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game : MonoBehaviour {

	public WallController tWall;
	public WallController lWall;
	public WallController rWall;
	public WallController bWall;

	public BallController ballCon;
	public PaddleController padCon;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {


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
			padCon.restart ();
			// Ball to original position
			ballCon.restart ();

			//TODO: Lose a life

			bWall.hit = false;

		}

	}
}
