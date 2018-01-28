﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fireballBehaviour : MonoBehaviour {


    public float thrust;
    public Rigidbody rb;
	public Vector3 direction;
	public float velocityThreshold;
	public float currentVelocity;

	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody>();
		rb.AddForce (direction) ;

	}
	
	// Update is called once per frame
	void FixedUpdate () {
		currentVelocity = rb.velocity.magnitude;
		if (rb.velocity.magnitude < velocityThreshold){
			var newForce = rb.velocity;
			newForce.x += Random.Range(-4,4);
			newForce.z += Random.Range(-4,4);
			rb.AddForce(newForce);
		}
	}

	public void registerHit(){
		currentVelocity = rb.velocity.magnitude;
		if (rb.velocity.magnitude < 15.0f){
			var newForce = rb.velocity;
			newForce.x += Random.Range(-4,4);
			newForce.z += Random.Range(-4,4);
			rb.AddForce(newForce);
			Debug.Log ("Le agregue fuerza");
		}
	}
		
}
