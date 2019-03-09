﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateWithPlayer : MonoBehaviour {

	public Transform target;
	public float rotationSpeed;
	void Start () {
		target = SpawnPlayerManager.instance.prefabToSpawn.transform;
	}
	
	void Update () {
		Rotate();
	}

	void Rotate()
	{
		transform.rotation = Quaternion.Slerp(target.rotation,transform.rotation,rotationSpeed);
	}
}
