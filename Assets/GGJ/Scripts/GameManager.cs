using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
	public static GameManager instance;

	private GGJCharacterEntity[] players;

	void Awake()
	{
		if (instance == null)
			instance = this;
		else if (instance != this)
			Destroy(gameObject);
		DontDestroyOnLoad(gameObject);

		InitGame();
	}

	private void InitGame()
	{
		players = new GGJCharacterEntity[2];
	}

	public void RegisterPlayer(GGJCharacterEntity playerEntity)
	{
		players[playerEntity.id] = playerEntity;
		playerEntity.OnPlayerDamaged += HandleOnPlayerDamaged;
		playerEntity.OnPlayerDeath += HandleOnPlayerDeath;

	}

	public GGJCharacterEntity GetPlayer(int id)
	{
		return players[id];
	}

	private void HandleOnPlayerDamaged(int id)
	{
		Debug.Log("Player " + id + " damaged! Health = " + GetPlayer(id).currentHealth);
	}

	private void HandleOnPlayerDeath(int id)
	{
		Debug.Log("Player " + id + " died!");
		GetPlayer(id).OnPlayerDamaged -= HandleOnPlayerDamaged;
		GetPlayer(id).OnPlayerDeath -= HandleOnPlayerDeath;
	}
}
