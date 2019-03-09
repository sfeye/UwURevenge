using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ShieldGen : Entity
{
    public ShieldArr parentArray;
    
    // Start is called before the first frame update
    void Start()
    {
        parentArray.shields.Add(gameObject);
        Debug.Log("Added");
    }

    
    public override void Die()
    {
        Debug.Log(parentArray.shields.Count);
        parentArray.OnDeath(gameObject);
        Debug.Log(parentArray.shields.Count);
        Destroy(gameObject);
        
        //Spawn Broken Shield Gen
        if(deathEffect != null)
        {
            Instantiate(deathEffect,transform.position,Quaternion.identity);
        }
    }
}
