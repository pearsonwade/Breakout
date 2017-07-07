﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallController : MonoBehaviour {

	public bool hit { get; set; } 

	// Use this for initialization
	void Start () {
		hit = false;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnCollisionEnter (Collision col) {

		if(col.gameObject.name == "Ball")
		{
			hit = true;
		}
	}
}
