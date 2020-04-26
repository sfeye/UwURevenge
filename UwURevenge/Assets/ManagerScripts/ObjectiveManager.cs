using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ObjectiveManager : MonoBehaviour
{   
    public static ObjectiveManager instance;
    public int numTurretsDestroyed = 0;

    void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(this);
        }
    }

    void Start()
    {

    }

    public void IncrementTurretObjective()
    {
        numTurretsDestroyed++;
    }
}
