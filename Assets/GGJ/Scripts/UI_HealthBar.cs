using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TeamUtility.IO;

public class UI_HealthBar : MonoBehaviour
{
	public PlayerID playerId;
	private Slider slider;

	private int _id;

	private void Start()
	{
		slider = GetComponentInChildren<Slider>();
		slider.value = 1;
		_id = (int)playerId;
		GameManager.instance.OnPlayerDamaged += HandleOnPlayerDamaged;
	}

	private void HandleOnPlayerDamaged(int id)
	{
		if (_id == id)
		{
			slider.value = GameManager.instance.GetPlayer(_id).currentHealth / GameManager.instance.GetPlayer(_id).maxHealth;

		}
	}

	public void Reset()
	{
		slider.value = 1;
	}

	private void OnDestroy()
	{
		GameManager.instance.OnPlayerDamaged -= HandleOnPlayerDamaged;
	}
}
