using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissileExplode : MonoBehaviour
{
    public float timeToDie;
    public float currAge = 0f;
    public GameObject FX_Explosion;

    void OnCollisionEnter(Collision other)
    {
        Explode();
    }
    void Update()
    {
        currAge += Time.deltaTime;
        if(currAge >= timeToDie)
        {
            Explode();
        }
    }

    void Explode()
    {
        Instantiate(FX_Explosion,transform.position,Quaternion.identity);
        //Deal damage to surrounding entities
        Destroy(gameObject);
    }
}
