﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GGJShield : MonoBehaviour
{
	public GGJCharacterEntity ownerEntity
	{ get; private set; }

	private Collider col;
	//private MeshRenderer r;

	public ParticleSystem pSystem;

	private void Start()
	{
		col = GetComponent<Collider>();
		//r = GetComponent<MeshRenderer>();
	}

	public void SetOwner(GGJCharacterEntity entity)
	{
		ownerEntity = entity;
	}

	public void EnableShield(bool enableShield = true)
	{
		//if (enableShield)
		//	r.material.SetColor("_Color", Color.red);
		//else
		//	r.material.SetColor("_Color", Color.white);
		col.enabled = enableShield;
	}
}