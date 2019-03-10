using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bridge : Entity
{
    public Material deactivationMaterial;
    Renderer rndr;
    
    void Start()
    {
        currHealth = maxHealth;
        rndr = GetComponent<Renderer>();
    }

    void Deactivate()
    {
        Material[] materials = rndr.materials;
        materials[1] = deactivationMaterial;
        rndr.materials = materials;
    }

    override public void Die()
    {
        Deactivate();
        Instantiate(deathEffect,transform.position,Quaternion.identity);
    }
}
