using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LavaAnimator : MonoBehaviour
{
	public Color colorA = Color.white;
	public Color colorB = Color.white;

	private Color lerpedColor;
	private Material m;

	private void Start()
	{
		m = GetComponent<MeshRenderer>().material;
	}
	void Update()
	{
		lerpedColor = Color.Lerp(colorA, colorB, Mathf.PingPong(Time.time, 1));
		m.SetColor("_EmissionColor", lerpedColor);

	}
}
