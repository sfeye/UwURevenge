using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour {

	public float maxSpeed;
	public float currSpeed;
	public float acceleration;
	float boostSpeed;
	// Use this for initialization

	void Awake()
	{
		if(MainMenuManager.instance.mode == 1)
		{
			this.enabled = false;
		}
	}
	// Update is called once per frame
	void Update () {
		if(Input.GetKey(KeyCode.W))
		{
			if(currSpeed < maxSpeed)
			{
				currSpeed += acceleration;
				if(currSpeed >= maxSpeed)
				{
					currSpeed = maxSpeed;
				}
			}
		}
		else if(Input.GetKey(KeyCode.S))
		{
			if(currSpeed > 0)
			{
				currSpeed -= (acceleration * 1.2f);
				if(currSpeed <= 0)
				{
					currSpeed = 0;
				}
			}
		}

		if(Input.GetKey(KeyCode.LeftShift))
		{
			movePlayer(currSpeed*2);
		}
		else
		{
			movePlayer(currSpeed);
		}
	}

	void movePlayer(float _speed)
	{
		transform.Translate(transform.InverseTransformDirection(transform.forward)*_speed*Time.deltaTime);
	}
}
