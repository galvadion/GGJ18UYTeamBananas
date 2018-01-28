using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightBehaviour : MonoBehaviour {

	int timer;


	// Use this for initialization
	void Start () {
		timer = 0;
	}

	// Update is called once per frame
	void Update () {
		transform.RotateAround (Vector3.zero, Vector3.left, 5 * Time.deltaTime);
	}
}
