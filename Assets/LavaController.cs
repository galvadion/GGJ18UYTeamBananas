using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LavaController : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void OnTriggerEnter(Collider other)
	{
		if(other.gameObject.tag=="Player"){
			Debug.Log("ACA VA EL DAÑo");
		}
	}

	public void OnCollisionEnter(Collision other)
	{
		if(other.gameObject.tag=="Player"){
			Debug.Log("ACA VA EL collision");
		}
	}
}
