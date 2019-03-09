using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class ProjectileHit : MonoBehaviour {

	public float damage;
	public GameObject FX_SmallBulletHit;
	void OnCollisionEnter(Collision collision)
	{
		try{ //Several ways of doing this. May want to change for performance
			Entity entityCollision = collision.transform.GetComponent<Entity>();
			entityCollision.TakeDamage(damage);
		}
		catch(NullReferenceException e)
		{
			//Do nothing
		}

		Instantiate(FX_SmallBulletHit,collision.contacts[0].point,Quaternion.identity);
		Die();
	}

	void Die()
	{
		Destroy(gameObject);
	}
}
