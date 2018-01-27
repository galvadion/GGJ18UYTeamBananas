using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TeamUtility.IO;

public class GGJCharacterWeapon : MonoBehaviour
{
	public float cooldown = 1f;
	private float currentCooldown = 0;
	private Animator _animator;

	private void Start()
	{
		_animator = GetComponent<Animator>();
	}

	private void Update()
	{
		if (currentCooldown > 0)
		{
			currentCooldown -= Time.deltaTime;
			return;
		}
	}

	public void Attack()
	{
		DoAttack();
	}

	private void DoAttack()
	{
		currentCooldown = cooldown;
		_animator.Play("SwordHit");

	}
}
