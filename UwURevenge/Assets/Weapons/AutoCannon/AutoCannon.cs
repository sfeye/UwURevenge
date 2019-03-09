using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoCannon : MonoBehaviour {
	public MotorRotate motor;
	public GameObject projectile;
	public Transform projectilePoint;
	float currentTimeToFire = 0f;
	public float rotationEpsilon = 10f;//Epsilon in degrees around y-axis
	public float roundsPerSecond = 1;
	float timeToFire = 0f;
	public AudioSource mAudio = null;
	public AudioClip laserBlast;
	

	void Start()
	{
		mAudio = GetComponent<AudioSource>();
		timeToFire = 1f/roundsPerSecond;
	}

	void Update () {
		if(Input.GetMouseButton(0) && motor.woundUp == true)
		{
			currentTimeToFire += Time.deltaTime;
			if(currentTimeToFire >= timeToFire)
			{
				FireProjectile();
			}
		}
	}

	void FireProjectile()
	{
		if(mAudio != null)
		{
			mAudio.PlayOneShot(laserBlast);
		}
		
		currentTimeToFire = 0f;
		GameObject tempProjectile = (GameObject) Instantiate(projectile);

		float projectileRotationY = Random.Range( transform.eulerAngles.y - rotationEpsilon, transform.eulerAngles.y + rotationEpsilon);
		float projectileRotationX = Random.Range( transform.eulerAngles.x - rotationEpsilon, transform.eulerAngles.x + rotationEpsilon);
		Vector3 projectileRotation = new Vector3( projectileRotationX, projectileRotationY, projectilePoint.eulerAngles.z);

		tempProjectile.transform.position = projectilePoint.position;
		tempProjectile.transform.rotation = Quaternion.Euler(projectileRotation);
	}
}
