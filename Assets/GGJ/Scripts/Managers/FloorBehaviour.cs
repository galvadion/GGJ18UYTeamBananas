using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class FloorBehaviour : MonoBehaviour
{
	List<GameObject> floors;
	float timer;
	bool active;
	private List<GameObject> floorTiles;
	private GameObject currentFloor;
	// Use this for initialization
	void Start()
	{
		floorTiles = GameObject.FindGameObjectsWithTag("Floor").ToList();
		InvokeRepeating("trembleFloor", 5, 8);
	}


	void trembleFloor()
	{
		timer = 0f;
		currentFloor = floorTiles[Random.Range(0, floorTiles.Count)];
		floorTiles.Remove(currentFloor);
		currentFloor.GetComponent<Animator>().SetTrigger("destroy");
	}


}
