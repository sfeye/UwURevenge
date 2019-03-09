using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatchShip : MonoBehaviour {

	public Squadron squadron;

	void Start()
	{
		squadron = GetComponent<Squadron>();
	}

	void OnTriggerEnter(Collider other)
	{
		if(other.tag == "player")
		{
			Debug.Log(other.name);
			GameObject shipToAdd = other.gameObject;
			
			if(squadron.SquadronListHasEmptySlot() && !squadron.ShipAlreadyInSquadron(shipToAdd))
			{
				Debug.Log("Ship not in squadron");
				squadron.SetOpenSlot(squadron.FindNextOpenSlot(),shipToAdd);
			}
			else
			{
				Debug.Log("Ship is already in squadron or squadron is full");
			}
		}
	}
}
