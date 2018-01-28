using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LavaAnimator : MonoBehaviour
{
	Material m;
	private void Start()
	{
		m = GetComponent<MeshRenderer>().material;
	}
}
