using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour {
	public float rotationCorrectionSpeed = 5f;
	public float bankRotationSpeed = 60f;
	public float rotationSpeed = 50.0f;
	Vector3 rotationAxis;


	void Start () {
		
	}
	

	void Update () {
		RotateObject();
		BankAircraft();
		RotateToOrigin();
	}

	void RotateObject()
	{
		float rotationX = Input.GetAxis("Mouse Y") * rotationSpeed * Time.deltaTime;
		float rotationY = Input.GetAxis("Mouse X") * rotationSpeed/3f * Time.deltaTime;
		rotationAxis = new Vector3(rotationX,rotationY,0f);
		transform.Rotate(rotationAxis);
	}

	void BankAircraft()
	{
		float rotationZ = Input.GetAxis("Horizontal") * -1f * Time.deltaTime;
		Vector3 bankRotation = new Vector3(0f,0f, rotationZ * bankRotationSpeed);
		transform.Rotate(bankRotation);
	}

	void RotateToOrigin()
	{
		var newRotation = Quaternion.Euler(0f,transform.eulerAngles.y,0f);
		transform.rotation = Quaternion.Slerp(transform.rotation, newRotation, rotationCorrectionSpeed*Time.deltaTime);
	}
}
