﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GGJTriggerDamage : MonoBehaviour
{
	private float _damage;
	private Collider col;
	public GGJCharacterWeapon ownerWeapon
	{ get; protected set; }

	private void Awake()
	{
		col = GetComponent<Collider>();
		col.isTrigger = true;
		col.enabled = false;
	}

	public void SetOwner(GGJCharacterWeapon weapon)
	{
		ownerWeapon = weapon;
	}

	public void EnableTrigger(bool enable = true)
	{
		col.enabled = enable;
	}

	public void SetDamage(float damage)
	{
		_damage = damage;
	}

	private void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.tag == "Player")
		{
			GGJCharacterEntity entity = other.gameObject.GetComponent<GGJCharacterEntity>();
			if (entity == null)
				return;
			if (entity == ownerWeapon.ownerEntity)
				return;
			entity.GetDamage(_damage);

		}

		if (other.gameObject.tag == "Shield")
		{
			GGJShield shield = other.gameObject.GetComponent<GGJShield>();
			if (shield == null)
				return;
			if (shield.ownerEntity == ownerWeapon.ownerEntity)
				return;
			ownerWeapon.ownerEntity.GetBlocked();

		}
	}
}
