using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fireballBehaviour : MonoBehaviour {

	private float _damage;
    public float thrust;
    public Rigidbody rb;
	public Vector3 direction;
	public float velocityThreshold;
	public float currentVelocity;

	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody>();
		rb.AddForce (direction) ;

	}
	
	// Update is called once per frame
	void FixedUpdate () {
		currentVelocity = rb.velocity.magnitude;
		if (rb.velocity.magnitude < velocityThreshold){
			var newForce = rb.velocity;
			newForce.x += Random.Range(-4,4);
			newForce.z += Random.Range(-4,4);
			rb.AddForce(newForce);
		}
	}

	private void OnCollisionEnter(Collision other)

	{
		if (other.gameObject.tag == "Shield")
		{
			GGJShield shield = other.gameObject.GetComponent<GGJShield>();
			if (shield == null)
				return;
			
			shield.pSystem.Play();

		}
		else if	(other.gameObject.tag == "Player")
		{
			GGJCharacterEntity entity = other.gameObject.GetComponent<GGJCharacterEntity>();
			if (entity == null)
				return;
			entity.GetDamage(2);

		}
	}

	public void registerHit(GameObject objeto){
		
		currentVelocity = rb.velocity.magnitude;
		//	var newForce;
			Debug.Log(objeto.GetComponent<Transform>().rotation.x);
			Debug.Log(objeto.GetComponent<Transform>().rotation.y);
			Debug.Log(objeto.GetComponent<Transform>().rotation.z);
			var newForce =objeto.GetComponent<Transform>().forward;
			//newForce = rb.velocity;
		//	newForce.z =objeto.GetComponent<Transform>().forward;
			Debug.Log(newForce.x);
			rb.AddForce(newForce);
	}
		
}
