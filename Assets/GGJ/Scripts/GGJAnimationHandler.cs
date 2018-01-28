using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GGJAnimationHandler : MonoBehaviour
{
	public GGJCharacterEntity entity;

	public void AttackEnd()
	{
		entity.AttackEnd();
	}
}
