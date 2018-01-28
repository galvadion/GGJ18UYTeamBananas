using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LavaFireTrigger : MonoBehaviour
{
	private Collider col;
	public ParticleSystem pSystem;

	void Start()
	{
		col = GetComponent<Collider>();
		col.enabled = false;
	}

	public void EnableTrigger()
	{
		col.enabled = true;
	}
	
	private void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.tag == "Player")
		{
			other.gameObject.GetComponent<GGJCharacterEntity>().GetDamage(GameManager.instance.lavaFloorDamage);
			col.enabled = false;
			TriggerAnimation();
			StartCoroutine(ReEnable(GameManager.instance.lavalFloorCooldown));
		}
	}

	IEnumerator ReEnable(float waitTime)
	{
		yield return new WaitForSeconds(waitTime);
		EnableTrigger();
	}

	private void TriggerAnimation()
	{
		pSystem.Play();
	}
}
