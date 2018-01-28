using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
	public static GameManager instance;

	private GameObject[] players;

	void Awake()
	{
		//Check if instance already exists
		if (instance == null)
			//if not, set instance to this
			instance = this;
		//If instance already exists and it's not this:
		else if (instance != this)
			//Then destroy this. This enforces our singleton pattern, meaning there can only ever be one instance of a GameManager.
			Destroy(gameObject);
		//Sets this to not be destroyed when reloading scene
		DontDestroyOnLoad(gameObject);

		InitGame();
	}

	private void InitGame()
	{
		players = new GameObject[2];
	}

	public void RegisterPlayer(int id, GameObject playerGameObject)
	{
		players[id] = playerGameObject;
	}

	public GameObject GetPlayer(int id)
	{
		return players[id];
	}
}
