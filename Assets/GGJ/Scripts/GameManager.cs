using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TeamUtility.IO;

public class GameManager : MonoBehaviour
{
	public float lavaFloorDamage = 5f;
	public float lavalFloorCooldown = 2f;
	public static GameManager instance;

	private GGJCharacterEntity[] players;
	private bool isGameOver = false;

	public System.Action<int> OnPlayerDamaged = null;
	private void RaiseOnPlayerDamaged(int id)
	{
		if (OnPlayerDamaged != null)
			OnPlayerDamaged(id);
	}

	public System.Action<int> OnGameOver = null;
	private void RaiseOnGameOver(int winId)
	{
		if (OnGameOver != null)
			OnGameOver(winId);
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
		Time.timeScale = 0;
		players = new GGJCharacterEntity[2];
	}

	public void StartGame()
	{
		isGameOver = false;
		Time.timeScale = 1;
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
		RaiseOnGameOver((id == 0) ? 1 : 0);
		Time.timeScale = 0;
		isGameOver = true;
	}
	private void Update()
	{
		if (isGameOver == false)
			return;
		if (InputManager.GetButtonDown("StartGame", PlayerID.One) || InputManager.GetButtonDown("StartGame", PlayerID.Two))
		{
			Scene scene = SceneManager.GetActiveScene();
			SceneManager.LoadScene(scene.name);
		}
	}
}
