using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatchShip : MonoBehaviour {

	public Squadron squadron;
	public GameObject autoCannon;

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
			
			if(squadron.SquadronListHasEmptySlot() && !squadron.ShipAlreadyInSquadron(shipToAdd) && shipToAdd != SpawnPlayerManager.instance.prefabToSpawn)
			{
				Debug.Log("Ship not in squadron");
				squadron.SetOpenSlot(squadron.FindNextOpenSlot(),shipToAdd);
				SquadronFighter temp = shipToAdd.GetComponent<SquadronFighter>();
				for(int i = 0; i < temp.autocannonSlots.Length; i++)
				{
					Instantiate(autoCannon,temp.autocannonSlots[i].position,temp.autocannonSlots[i].rotation,temp.autocannonSlots[i]);
				}
			}
			else
			{
				Debug.Log("Ship is already in squadron or squadron is full");
			}
		}
	}
}
