using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Entity : MonoBehaviour {

	public string entityName;
	public float maxHealth;
	public float currHealth;
	public GameObject deathEffect;

	void Start()
	{
		currHealth = maxHealth;
	}

	virtual public void TakeDamage(float damageToTake)
	{
		currHealth -= damageToTake;

		if(currHealth <= 0)
		{
			Die();
		}
	}

	virtual public void Die()
	{
		Destroy(gameObject);
		if(deathEffect != null)
		{
			Instantiate(deathEffect,transform.position,Quaternion.identity);
		}
	}
}
