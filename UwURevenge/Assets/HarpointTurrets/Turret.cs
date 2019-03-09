using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret : Entity
{
    void Start()
    {
        currHealth = maxHealth;
    }
    override public void Die()
    {
        ObjectiveManager.instance.IncrementTurretObjective();
        Instantiate(deathEffect,transform.position,Quaternion.identity);
        Destroy(gameObject);
    }
}
