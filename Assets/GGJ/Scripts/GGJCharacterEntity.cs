using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TeamUtility.IO;

public class GGJCharacterEntity : MonoBehaviour
{
	[Header("Stats")]
	public float maxHealth;
	public float stunTime = 1f;

	public float walkSpeed = 3f;
	public float runSpeed = 6f;

	public float jumpHeight = 1f;
	public float gravity = -11f;

	public float speedSmoothTime = 0.2f;
	public float rotSmoothTime = 0.1f;

	[Header("Controller setup")]
	public PlayerID playerID;

	public int id
	{ get; private set; }

	public float currentHealth
	{ get; private set; }

	public bool isDead
	{ get; private set; }

	public bool isStunned
	{ get; private set; }

	public bool isAttacking
	{ get; protected set; }

	public bool hitSomething
	{ get; protected set; }

	private Animator _animator;
	private GGJCharacterWeapon weapon;
	private GGJCharacterController controller;

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

	public Animator animator
	{ get; private set; }

	private void Start()
	{
		id = (int)playerID;
		GameManager.instance.RegisterPlayer(this);
		currentHealth = maxHealth;
		_animator = GetComponent<Animator>();
		weapon = GetComponent<GGJCharacterWeapon>();
		controller = GetComponent<GGJCharacterController>();
		isDead = false;
		animator = GetComponentInChildren<Animator>();
		isAttacking = false;
		hitSomething = false;
	}

	public void GetDamage(float damage)
	{
		currentHealth -= damage;
		isStunned = true;
		weapon.shield.EnableShield(!isStunned);
		StartCoroutine(UnStun(stunTime));

		RaiseOnPlayerDamaged();

		if (currentHealth <= 0)
		{
			currentHealth = 0;
			Die();
		}
	}

	public void GetBlocked()
	{
		animator.SetTrigger("ShieldBlock");
		AttackEnd();
		Debug.Log("<b> BLOCKED </b>");
	}

	private void Die()
	{
		animator.SetTrigger("Death");
		isDead = true;
		RaiseOnPlayerDeath();
	}
	 IEnumerator UnStun(float waitTime)
	{
		yield return new WaitForSeconds(waitTime);
		isStunned = false;
		weapon.shield.EnableShield(!isStunned);
	}

	public void Attack()
	{
		isAttacking = true;
		hitSomething = false;
		weapon.Attack();
	}

	public void HitSomething()
	{
		hitSomething = true;
	}

	public void AttackEnd()
	{
		isAttacking = false;
		weapon.AttackEnd();
	}
}
