using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloorEntity : MonoBehaviour
{

	private float duration;
	private LavaFireTrigger fireTrigger;

	private void Start()
	{
		duration = 3f;
		int i = Random.Range(0, 4);
		if (i == 1)
		{
			transform.Rotate(Vector3.up, 90);
		}
		else if (i == 2)
		{
			transform.Rotate(Vector3.up, 180);
		}
		else if (i == 3)
		{
			transform.Rotate(Vector3.up, -90);
		}
		fireTrigger = GetComponentInChildren<LavaFireTrigger>();
	}

	public void reduceCountDown(){
		duration -= Time.deltaTime;
		
		if (duration < 0f) {
			this.GetComponent<Animator> ().SetBool("destroy", true);
			//this.GetComponent<MeshRenderer> ().enabled = false;
		}
	}

	public void resetCountDown(){
		duration = 3f;
	}

	public void enableFireTrigger()
	{
		fireTrigger.EnableTrigger();
	}
}