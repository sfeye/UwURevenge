using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MotorRotate : MonoBehaviour {

	public float currentMotorSpeed = 0f;
	public float windupSpeed = 180;
	public float maxSpeed = 720;
	public bool woundUp = false;
	void Update () {
		if(Input.GetMouseButton(0))//should probably use coroutines ;(
		{
			windUp();
		}
		else
		{
			if(currentMotorSpeed > 0)
			{
				windDown();
			}
		}

		if(currentMotorSpeed > 0)
		{
			RotateMotor();
		}
	}

	void RotateMotor()
	{
		transform.Rotate(0f,0f,currentMotorSpeed*Time.deltaTime);
	}
	void windUp()
	{
		if(currentMotorSpeed < maxSpeed)
		{
			currentMotorSpeed += windupSpeed*Time.deltaTime;
		}
		else
		{
			if(woundUp == false)
			{
				woundUp = true;
			}
			currentMotorSpeed = maxSpeed;
		}
	}
	void windDown()
	{
		if(currentMotorSpeed > 0)
		{
			if(woundUp == true)
			{
				woundUp = false;
			}
			currentMotorSpeed -= windupSpeed*2*Time.deltaTime;
		}
		else
		{
			currentMotorSpeed = 0;
		}
	}
}
