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
		if (active) {
			if (timer <= 4) {
				if (timer % 2 > 1) {

					floorEntity.GetComponent<Transform> ().position = new Vector3 (
						floorEntity.GetComponent<Transform> ().position.x + 0.005f,
						floorEntity.GetComponent<Transform> ().position.y,
						floorEntity.GetComponent<Transform> ().position.z + 0.005f
					);
				} else {

					floorEntity.GetComponent<Transform> ().position = new Vector3 (
						floorEntity.GetComponent<Transform> ().position.x - 0.005f,
						floorEntity.GetComponent<Transform> ().position.y,
						floorEntity.GetComponent<Transform> ().position.z - 0.005f
					);
				}

			} else {
				Destroy (floorEntity);
				active = false;
			}
			timer += Time.deltaTime;
		}
	}


	void trembleFloor()
	{
		active = true;
			timer = 0f;
			floorEntity = GameObject.FindGameObjectsWithTag ("Floor") [Random.Range (0, 340)];
			floorEntity.GetComponent<Transform> ().position = new Vector3 (
				floorEntity.GetComponent<Transform> ().position.x,
				floorEntity.GetComponent<Transform> ().position.y + 0.10f,
				floorEntity.GetComponent<Transform> ().position.z
			);


	}


}
