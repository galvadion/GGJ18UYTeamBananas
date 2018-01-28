using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloorDetection : MonoBehaviour {

	public LayerMask layerMask;
	private FloorEntity floors;
	public float rayLength;
	private Ray ray;
	//private int _layerMask;

	// Use this for initialization
	void Start () {
		//_layerMask = (int)layerMask;
		//_layerMask = ~_layerMask;
	}
	
	// Update is called once per frame
	void Update () {
		ray = new Ray (transform.position + Vector3.up * 2, Vector3.down);
		RaycastHit hit;

		if (Physics.Raycast(ray, out hit, rayLength, layerMask))
		{
			Debug.Log("HIT " + hit.collider.gameObject.name);
			var newFloor = hit.collider.GetComponent<FloorEntity>();
			if (floors == null)
			{
				if (newFloor == null)
					return;
				floors = newFloor;
				floors.reduceCountDown();
			}
			else
			{
				if (newFloor == floors)
				{
					newFloor.reduceCountDown();
				}
				else
				{
					floors.resetCountDown();
					floors = newFloor;
					floors.reduceCountDown();
				}
			}
		}

	}

	private void OnDrawGizmos()
	{
		Debug.DrawLine(ray.origin, ray.origin + ray.direction * 3);
	}


}
