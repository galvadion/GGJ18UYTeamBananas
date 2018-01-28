using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloorDetection : MonoBehaviour {

	public LayerMask layerMask;
	private FloorEntity floors;
	public float rayLength;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		var ray = new Ray (transform.position, Vector3.down);
		RaycastHit hit;
		
		if (Physics.Raycast (ray, out hit, rayLength, layerMask)) {
			
			var newFloor = hit.collider.GetComponent<FloorEntity> ();
			if (newFloor.Equals (floors)) {
				Debug.Log ("Le estoy golpeando a " + newFloor.gameObject.name);
				newFloor.reduceCountDown ();
			}
			else {
				
				if (floors != null) {
					Debug.Log ("Le estoy adsada a " + floors.gameObject.name);
					floors.resetCountDown ();
				}
				Debug.Log ("Le estoy asdas 2 a " + newFloor.gameObject.name);

				floors = newFloor;
			}
		}else{
		
		}
	}


}
