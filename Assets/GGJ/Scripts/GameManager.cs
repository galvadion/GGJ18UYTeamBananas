using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
	public static GameManager instance;

	private GGJCharacterEntity[] players;

	public System.Action<int> OnPlayerDamaged = null;
	private void RaiseOnPlayerDamaged(int id)
	{
		if (OnPlayerDamaged != null)
			OnPlayerDamaged(id);
	}

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
		RaiseOnPlayerDamaged(id);
		Debug.Log("Player " + id + " damaged! Health = " + GetPlayer(id).currentHealth);
	}

	private void HandleOnPlayerDeath(int id)
	{
		Debug.Log("Player " + id + " died!");
		GetPlayer(id).OnPlayerDamaged -= HandleOnPlayerDamaged;
		GetPlayer(id).OnPlayerDeath -= HandleOnPlayerDeath;
	}
	private void Update()
	{
		if (Input.GetKeyDown(KeyCode.R))
		{
			Scene scene = SceneManager.GetActiveScene();
			SceneManager.LoadScene(scene.name);
		}
	}
}
