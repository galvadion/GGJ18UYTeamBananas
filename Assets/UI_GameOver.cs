using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TeamUtility.IO;

public class UI_GameOver : MonoBehaviour
{
	public GameObject gameOverPanel;
	public Text gameOver;

	private int _id;

	private void Start()
	{
		GameManager.instance.OnGameOver += HandleOnGameOver;
	}

	private void HandleOnGameOver(int winid)
	{
		gameOverPanel.SetActive(true);
		gameOver.text = string.Format(gameOver.text, ((PlayerID)winid).ToString());
	}

	private void OnDestroy()
	{
		GameManager.instance.OnGameOver -= HandleOnGameOver;
	}
}
