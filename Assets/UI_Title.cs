using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TeamUtility.IO;

public class UI_Title : MonoBehaviour {

	private void Update()
	{
		if (InputManager.GetButtonDown("StartGame", PlayerID.One) || InputManager.GetButtonDown("StartGame", PlayerID.Two))
		{
			GameManager.instance.StartGame();
			this.gameObject.SetActive(false);
		}
	}
}
