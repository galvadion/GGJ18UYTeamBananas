using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TeamUtility.IO;

public class MiddleController
	: MonoBehaviour
{
	public GameObject player1;
	public GameObject player2;

    void Update()
	{
		/*this.transform.position.x = player1.transform.position.x + (player2.transform.position.x - player1.transform.position.x)/2;
		this.transform.position.y = player1.transform.position.y + (player2.transform.position.y - player1.transform.position.y)/2;
		this.transform.position.z = player1.transform.position.z + (player2.transform.position.z - player1.transform.position.z)/2;*/
		GetComponent<Rigidbody>().MovePosition(new Vector3 (player1.transform.position.x + (player2.transform.position.x - player1.transform.position.x)/2, 
			player1.transform.position.y + (player2.transform.position.y - player1.transform.position.y)/2,player1.transform.position.z + (player2.transform.position.z - player1.transform.position.z)/2));
	}
}