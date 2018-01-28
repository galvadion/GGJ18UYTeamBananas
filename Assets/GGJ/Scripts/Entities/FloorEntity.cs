using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloorEntity : MonoBehaviour {

	private float duration;

	// Use this for initialization
	void Start () {
		duration = 5f;
	}

	// Update is called once per frame
	void Update () {

	}

	public void reduceCountDown(){
		duration -= Time.deltaTime;
		Debug.Log ("Iam reducing a cooldown" + duration + this.gameObject.name);
		if (duration < 0f) {
			this.GetComponent<Animator> ().SetTrigger ("destroy");
			this.GetComponent<MeshRenderer> ().enabled = false;
		}
	}

	public void resetCountDown(){
		Debug.Log ("Iam reloading a cooldown named" + this.gameObject.name);
		duration = 5f;
	}
}