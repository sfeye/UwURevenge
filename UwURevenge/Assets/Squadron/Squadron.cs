using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Squadron : MonoBehaviour {

	public GameObject[] squadronList = new GameObject[3];
    public Transform[] squadronPositions = new Transform[3];

    public bool ShipAlreadyInSquadron(GameObject ship)
    {
        for( int i = 0; i<squadronList.Length; i++)
        {
            if(squadronList[i] == ship)
            {
                return true;
            }
        }

        return false;
    }

    public bool SquadronListHasEmptySlot()
    {
        
        for( int i = 0; i<squadronList.Length; i++)
        {
            if(squadronList[i] == null)
            {
                return true;
            }
        }
        
        return false;
    }

    public int FindNextOpenSlot()
    {
        for( int i = 0; i<squadronList.Length; i++)
        {
            if(squadronList[i] == null)
            {
                return i;
            }
        }

        return -1;
    }

    public void SetOpenSlot(int index, GameObject ship)
    {
        if(index >= 0)
        {
            squadronList[index] = ship;
            SnapShipToSquadronPosition(index,ship);
        }
    }

    void SnapShipToSquadronPosition(int index, GameObject ship)
    {
        ship.transform.SetParent(squadronPositions[index]);
        ship.transform.position = ship.transform.parent.position;
        ship.transform.rotation = ship.transform.parent.rotation;
    }
}
