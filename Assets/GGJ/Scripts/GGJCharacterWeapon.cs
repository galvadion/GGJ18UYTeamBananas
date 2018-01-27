using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TeamUtility.IO;

public class GGJCharacterWeapon : MonoBehaviour
{
	public GGJTriggerDamage weaponDamageTrigger;
	public GGJShield shield;
	public float damage = 2f;
	public float cooldown = 1f;
	public GGJCharacterEntity ownerEntity;
	private float currentCooldown = 0;


	private void Start()
	{
		weaponDamageTrigger.SetDamage(damage);
		weaponDamageTrigger.EnableTrigger(false);
	}

	private void Update()
	{
		if (currentCooldown > 0)
		{
			currentCooldown -= Time.deltaTime;
		}
	}

	public void SetOwner(GGJCharacterEntity entity)
	{
		ownerEntity = entity;
		weaponDamageTrigger.SetOwner(this);
		shield.SetOwner(ownerEntity);
	}

	public void Attack()
	{
		if (currentCooldown > 0)
			return;
		weaponDamageTrigger.EnableTrigger(true);
		currentCooldown = cooldown;
		ownerEntity.animator.SetTrigger("SwordHit");
	}

	public void AttackEnd()
	{
		weaponDamageTrigger.EnableTrigger(false);
	}
}
