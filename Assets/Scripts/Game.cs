using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class Game : MonoBehaviour {

	//Levels
	private int levelCount;
	public GameObject[] levels = new GameObject[3];
	public int brickCount;

	//Objects
	public BallController ballCon;
	public PaddleController padCon;

	//Images
	public Image gameOver;
	public Image gameWin;

	//Life
	private int life;
	public Text lifeText;

	//Reset ball and paddle to original positions at every new game, level, or life
	public void resetPlayer() {
		padCon.restart ();
		ballCon.restart ();
	}

	//Produce amount of lives
	public void displayLives() {
		lifeText.text = "Lives: " + life.ToString ();
	}


	//Player life is lost
	public void loseLife () {

		resetPlayer ();
		--life;

		//Prevent "lives = -1"
		if (life >= 0) {
			displayLives ();
		}
	}

	//Pause gameplay at end of game
	public void stopGame() {
		Time.timeScale = 0;

		//Initiate new game
		if (Input.GetKeyDown ("space")) {
			life = 2;
			levelCount = 0;
			beginLevel ();
			brickCount = levels[0].transform.childCount;
		}
	}

	//Set up desired level to play
	public void beginLevel() {
		levelSwitch (levelCount);
		displayLives ();
		gameOver.gameObject.SetActive (false);
		gameWin.gameObject.SetActive (false);
		resetPlayer ();
		Time.timeScale = 1;
	}

	//Navigate through array for correct level
	public void levelSwitch(int level) {

		//Deactivate all levels
		for (int i = 0; i < levels.Length; i++) {
			levels[i].gameObject.SetActive (false);
		}

		//Activate desired level
		levels [level].gameObject.SetActive (true);
		brickCount = levels [level].transform.childCount;
	}

	//Initialization
	void Start () {
		life = 2;
		brickCount = levels[0].transform.childCount;
		levelCount = 0;
		beginLevel ();
	}
	
	//Once per frame
	void Update () {

		//Winning conditions
		if (brickCount <= 0) {

			if (levelCount < levels.Length - 1) {
				++levelCount;
				beginLevel ();
			} else {
				gameWin.gameObject.SetActive (true);
				stopGame ();
			}

		//Losing conditions
		} else if (life < 0) {
			
			gameOver.gameObject.SetActive (true);
			stopGame ();
		}
	}
}
