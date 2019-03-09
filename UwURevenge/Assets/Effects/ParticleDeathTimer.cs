using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleDeathTimer : MonoBehaviour {

	float currentAge = 0f;
	public float lifeSpan = 0f;
	
	void Update () {
		currentAge += Time.deltaTime;
		if(currentAge >= lifeSpan)
		{
			Destroy(gameObject);
		}
	}
}
