using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GGJTriggerDamage : MonoBehaviour
{
	private float _damage;
	private Collider col;
	public GGJCharacterWeapon ownerWeapon
	{ get; protected set; }
	public AudioClip[] SwordHit;
	public AudioClip[] SwordSwoosh;
	public AudioClip[] SwordBlock;

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
		if (ownerWeapon.ownerEntity.isAttacking == false)
			return;
		if (ownerWeapon.ownerEntity.hitSomething == true)
			return;

		if (other.gameObject.tag == "Shield")
		{
			GGJShield shield = other.gameObject.GetComponent<GGJShield>();
			if (shield == null)
				return;
			if (shield.ownerEntity == ownerWeapon.ownerEntity)
				return;
			shield.pSystem.Play();
			var source =this.GetComponent<AudioSource>();
			source.clip = SwordBlock[Random.Range(0, SwordBlock.Length)];
			source.Play();
			ownerWeapon.ownerEntity.GetBlocked();

		}
		else if	(other.gameObject.tag == "Player")
		{
			GGJCharacterEntity entity = other.gameObject.GetComponent<GGJCharacterEntity>();
			if (entity == null)
				return;
			if (entity == ownerWeapon.ownerEntity)
				return;
			ownerWeapon.ownerEntity.HitSomething();
			var source =this.GetComponent<AudioSource>();
			source.clip = SwordHit[Random.Range(0, SwordHit.Length)];
			source.Play();
			entity.GetDamage(_damage);

		}
		else if	(other.gameObject.tag == "Fireball")
		{
			fireballBehaviour entity = other.gameObject.GetComponent<fireballBehaviour>();
			entity.registerHit (ownerWeapon.ownerEntity.gameObject);

		}
	}
}
