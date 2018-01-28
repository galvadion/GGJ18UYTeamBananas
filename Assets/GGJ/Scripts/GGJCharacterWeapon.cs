using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TeamUtility.IO;

public class GGJCharacterWeapon : MonoBehaviour
{
	public GGJTriggerDamage weaponDamageTrigger;
	public float damage = 2f;
	public float cooldown = 1f;
	private float currentCooldown = 0;
	private Animator _animator;
	public GGJCharacterEntity ownerEntity;

	private void Start()
	{
		_animator = GetComponent<Animator>();
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
	}

	public void Attack()
	{
		DoAttack();
	}

	private void DoAttack()
	{
		if (currentCooldown > 0)
			return;
		weaponDamageTrigger.EnableTrigger(true);
		currentCooldown = cooldown;
		_animator.SetTrigger("SwordHit");

	}

	public void AttackEnd()
	{
		weaponDamageTrigger.EnableTrigger(false);
	}
}
