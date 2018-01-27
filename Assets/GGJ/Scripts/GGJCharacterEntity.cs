using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TeamUtility.IO;

public class GGJCharacterEntity : MonoBehaviour
{
	[Header("Stats")]
	public float health;

	public float walkSpeed = 3f;
	public float runSpeed = 6f;

	public float jumpHeight = 1f;
	public float gravity = -11f;

	public float speedSmoothTime = 0.2f;
	public float rotSmoothTime = 0.1f;

	[Header("Controller setup")]
	public PlayerID playerID;

	public int id
	{
		get; protected set;
	}

	public System.Action<int> OnPlayerDeath = null;
	private void RaiseOnPlayerDeath()
	{
		if (OnPlayerDeath != null)
			OnPlayerDeath((int)playerID);
	}

	public System.Action<int> OnPlayerDamaged = null;
	private void RaiseOnPlayerDamaged()
	{
		if (OnPlayerDamaged != null)
			OnPlayerDamaged((int)playerID);
	}

	private void Start()
	{
		id = (int)playerID;
		GameManager.instance.RegisterPlayer(this);
	}

	public void GetDamage(float damage)
	{
		health -= damage;
		RaiseOnPlayerDamaged();

		if (health <= 0)
		{
			health = 0;
		}
		RaiseOnPlayerDeath();
	}
}
