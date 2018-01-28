using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TeamUtility.IO;

public class CameraController
	: MonoBehaviour
{
	public MiddleController target;//the target object
	private float speedMod = 10.0f;//a speed modifier
	private Vector3 point;//the coord to the point where the camera looks at
	//var middle:transform;
//	public GameObject middle;

	void Start () {//Set up things on the start method
		point = target.transform.position;//get target's coords
		transform.LookAt(point);//makes the camera look to it
	}

    void Update()
	{
		point = target.transform.position;
		transform.LookAt (point);
	}
}