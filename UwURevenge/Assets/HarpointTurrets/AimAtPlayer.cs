using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AimAtPlayer : MonoBehaviour {

	public Transform target;
	public Transform projectilePoint;
	public float distanceToFire;
	public float rotationSpeed;

	public GameObject projectile;
	public float roundsPerSecond;
	public float rotationEpsilon;
	float timeToFire;
	float currentTimeToFire;

	void Start () {
		timeToFire = 1/roundsPerSecond;
	}
	
	void Update()
	{
		if(Vector3.Distance(target.position,transform.position) < distanceToFire)
		{
			TrackTarget();
			currentTimeToFire += Time.deltaTime;
			if(currentTimeToFire >= timeToFire)
			{
					
				FireAtTarget();
				currentTimeToFire = 0f;
			}
		}
	}

	void TrackTarget()
	{
		transform.LookAt(target.position);
	}

	void FireAtTarget()
	{
		currentTimeToFire = 0f;
		GameObject tempProjectile = (GameObject) Instantiate(projectile);

		float projectileRotationY = Random.Range( transform.eulerAngles.y - rotationEpsilon, transform.eulerAngles.y + rotationEpsilon);
		float projectileRotationX = Random.Range( transform.eulerAngles.x - rotationEpsilon, transform.eulerAngles.x + rotationEpsilon);
		Vector3 projectileRotation = new Vector3( projectileRotationX, projectileRotationY, projectilePoint.eulerAngles.z);

		tempProjectile.transform.position = projectilePoint.position;
		tempProjectile.transform.rotation = Quaternion.Euler(projectileRotation);
	}

	bool CheckIfPlayerInSight()
	{
		RaycastHit hit;
		
		if(Physics.Raycast(projectilePoint.position,transform.forward,out hit,distanceToFire))
		{
			if(hit.transform.tag == "player")
			{
				Debug.DrawRay(projectilePoint.position,transform.forward*distanceToFire,Color.red);
				Debug.Log("Player in sight");
				return true;
			}
		}

		return false;
	}
}
