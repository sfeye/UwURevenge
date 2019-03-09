using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleshipArtillery : MonoBehaviour
{
    public LineRenderer laser;
    public Transform projectilePoint;
    public GameObject onHitEffect;
    float timeToFire;
    float deltaTimeToFire;
    float laserMultiplier = 2;
    
    void Start()
    {
        laser = GetComponent<LineRenderer>();
        laser.enabled = false;

        timeToFire = Random.Range(5f,10f);
    }
    void Update()
    {
        //Debug.DrawRay(projectilePoint.position,projectilePoint.forward*2000f,Color.red);
        deltaTimeToFire += Time.deltaTime;
        if(deltaTimeToFire >= timeToFire)
        {
            StartCoroutine("FireLaser");
            timeToFire = Random.Range(5f,10f);
            deltaTimeToFire = 0;
        }

        if(laser.enabled)
        {
            laserMultiplier += 5f*Time.deltaTime;
            laser.widthMultiplier = laserMultiplier;

        }
        else
        {
            laserMultiplier = 0f;
        }
    }

    Vector3 CastRay()
    {
        RaycastHit hit;
        Ray rayCast = new Ray(projectilePoint.position,projectilePoint.forward);

        if(Physics.Raycast(rayCast,out hit,5000f))
        {
                return hit.point;
        }
        else
        {
            return new Vector3(0,0,0);
        }
    }

    void DrawLine()
    {
        Vector3 pointToHit = CastRay();
        laser.SetPosition(0,projectilePoint.position);
        laser.SetPosition(1,CalculateMidPoint(projectilePoint.position,pointToHit));
        laser.SetPosition(2,pointToHit);
        laser.enabled = true;
        Instantiate(onHitEffect,pointToHit,Quaternion.identity);
    }

    void ClearLine()
    {
        laser.enabled = false;
    }

    Vector3 CalculateMidPoint(Vector3 _origin, Vector3 endPoint)
    {

        Vector3 midPoint = new Vector3((_origin.x+endPoint.x)/2,(_origin.y+endPoint.y)/2,(_origin.z+endPoint.z)/2);

        return midPoint;
    }

    IEnumerator FireLaser()
    {
        DrawLine();
        yield return new WaitForSeconds(2f);
        ClearLine();
        StopCoroutine(FireLaser());
    }
}
