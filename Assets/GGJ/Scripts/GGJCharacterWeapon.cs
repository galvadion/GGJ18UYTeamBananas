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
	public TrailRenderer trail;
	public Animator collidersAnimator;
	public AudioClip[] SwordSwoosh;


	private float currentCooldown = 0;

	private void Start()
	{
		weaponDamageTrigger.SetDamage(damage);
		weaponDamageTrigger.EnableTrigger(false);
		trail.enabled = false;
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
		collidersAnimator.SetTrigger("SwingSword");
		trail.enabled = true;

		var source =this.GetComponent<AudioSource>();
		source.clip = SwordSwoosh[Random.Range(0, SwordSwoosh.Length)];
		source.Play();
	}

	public void AttackEnd()
	{
		weaponDamageTrigger.EnableTrigger(false);
		trail.enabled = false;
	}
}
