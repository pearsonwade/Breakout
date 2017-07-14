using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class Game : MonoBehaviour {

	private int levelCount;
	public GameObject[] levels = new GameObject[3];

	public BallController ballCon;
	public PaddleController padCon;

	public Image gameOver;
	public Image gameWin;

	private int life;
	public Text lifeText;

	//public bool brickReset { get; set; }
	public int brickCount;

	public void resetPlayer() {
		padCon.restart ();
		ballCon.restart ();
	}

	public void displayLives() {
		
		lifeText.text = "Lives: " + life.ToString ();
	}

	public void loseLife () {

		resetPlayer ();
		--life;

		if (life >= 0) {
			displayLives ();
		}
	}

	public void stopGame() {
		Time.timeScale = 0;
		//brickReset = true;

		if (Input.GetKeyDown ("space")) {
			life = 2;
			levelCount = 0;
			beginLevel ();
			brickCount = levels[0].transform.childCount;

		}
	}

	public void beginLevel() {
		levelSwitch (levelCount);
		displayLives ();
		gameOver.gameObject.SetActive (false);
		gameWin.gameObject.SetActive (false);
		resetPlayer ();
		Time.timeScale = 1;
	}

	public void levelSwitch(int level) {
		
		for (int i = 0; i < levels.Length; i++) {
			levels[i].gameObject.SetActive (false);
		}

		levels [level].gameObject.SetActive (true);
		brickCount = levels [level].transform.childCount;
	}

	// Use this for initialization
	void Start () {
		life = 2;
		brickCount = levels[0].transform.childCount;
		levelCount = 0;
		beginLevel ();

	}
	
	// Update is called once per frame
	void Update () {
		
		if (brickCount <= 0) {

			if (levelCount < levels.Length - 1) {
				++levelCount;
				beginLevel ();
			} else {
				gameWin.gameObject.SetActive (true);
				stopGame ();
			}

		} else if (life < 0) {
			
			gameOver.gameObject.SetActive (true);
			stopGame ();
		}
	}
}
