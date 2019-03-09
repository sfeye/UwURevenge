using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour {

	public float speed = 5f;
	float boostSpeed;
	// Use this for initialization
	void Start () {
		boostSpeed = 2*speed;
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKey(KeyCode.LeftShift))
		{
			movePlayer(boostSpeed);
		}
		else
		{
			movePlayer(speed);
		}
	}

	void movePlayer(float _speed)
	{
		transform.Translate(transform.InverseTransformDirection(transform.forward)*_speed*Time.deltaTime);
	}
}
