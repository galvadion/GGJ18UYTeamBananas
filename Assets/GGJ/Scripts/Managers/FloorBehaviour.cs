using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloorBehaviour : MonoBehaviour {
	List<GameObject> floors;
	float timer;
	bool active;
	GameObject floorEntity;
	// Use this for initialization
	void Start () {
	//	 floors =   GameObject.FindGameObjectsWithTag ("Floor");
		int floorLength =  GameObject.FindGameObjectsWithTag ("Floor").Length;
		//active = true;
		InvokeRepeating ("trembleFloor", 5, 15);
	}
	
	// Update is called once per frame
	void Update () {
		
		/*if (active) {

			this.GetComponent<Animator> ().SetTrigger ("destroy");
			Destroy (floorEntity);
			active = false;
		}*/
	}


	void trembleFloor()
	{
		active = true;
			timer = 0f;
			floorEntity = GameObject.FindGameObjectsWithTag ("Floor") [Random.Range (0, 340)];
		floorEntity.GetComponent<Animator> ().SetTrigger ("destroy");
		Destroy (floorEntity);
		active = false;

	}


}
