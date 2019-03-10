using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissileLauncher : MonoBehaviour
{
    public Transform projectilePoint;
    public Transform rayPoint;
    public GameObject missile;
    public float rotationEpsilon = 0f;
    
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            LaunchMissile();
        }
    }

    void LaunchMissile()
    {
        Vector3 targetPos = GetPointToHit();
        
        GameObject missileTemp = Instantiate(missile,projectilePoint.position,projectilePoint.rotation);    
        missileTemp.GetComponent<Missile>().target = targetPos;
    }

    Vector3 GetPointToHit()
    {
            return rayPoint.forward * 750f;
    }
}
