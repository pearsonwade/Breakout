using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaddleController : MonoBehaviour {


	//Paddle speed
	private float speed = 20.0f;
	private Vector3 paddleStart;

	//If collide
	public bool hit { get; set; } 

	//Ball back to starting point
	public void restart () {
		this.transform.position = paddleStart;
	}

	void Start () {
		paddleStart = new Vector3 (this.transform.position.x, this.transform.position.y, this.transform.position.z);
	}
	
	// Update is called once per frame
	void Update () {

		//Movement based on horizontal input
		Vector3 direction = new Vector3 (Input.GetAxis ("Horizontal"), 0, 0);

		//Move paddle
		this.transform.Translate (direction * speed * Time.deltaTime);
	}

	//Collsion notification
	void OnCollisionEnter (Collision col) {
		
		hit = true;
	}
}


