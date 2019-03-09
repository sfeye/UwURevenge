using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SquadronFighter : MonoBehaviour
{   
    public GameObject naviMeshArrowPointer;
    public Transform[] autocannonSlots;

    public void RemoveNaviMesh()
    {
        Destroy(naviMeshArrowPointer);
    }

}
