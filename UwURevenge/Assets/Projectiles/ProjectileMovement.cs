using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileMovement : MonoBehaviour {

	Rigidbody rb;
	public float speed;
	public float currentLife;
	public float maxLife;
	public string layerToIgnore;
	void Start()
	{
		rb = GetComponent<Rigidbody>();
		Physics.IgnoreLayerCollision(LayerMask.NameToLayer(layerToIgnore),LayerMask.NameToLayer(layerToIgnore));
		Physics.IgnoreLayerCollision(LayerMask.NameToLayer(layerToIgnore),LayerMask.NameToLayer("Shield"));
		Move();
	}
	
	void Update () {
		currentLife += Time.deltaTime;
		if(currentLife >= maxLife)
		{
			Die();
		}
	}

	void FixedUpdate()
	{
		
	}

	void Move()
	{
		//transform.Translate(transform.InverseTransformDirection(transform.forward)*speed*Time.deltaTime);
		rb.AddForce(transform.forward*speed, ForceMode.Impulse);
	}
	void Die()
	{
		Destroy(gameObject);
	}
}
