using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatchShip : MonoBehaviour {

	public Squadron squadron;
	public GameObject autoCannon;

	void Start()
	{
		squadron = GetComponent<Squadron>();
		Physics.IgnoreLayerCollision(LayerMask.NameToLayer("Squadron"),LayerMask.NameToLayer("Allies"));
		Physics.IgnoreLayerCollision(LayerMask.NameToLayer("Squadron"),LayerMask.NameToLayer("Enemies"));
	}

	void OnTriggerEnter(Collider other)
	{
		if(other.tag == "squadron")
		{
			Debug.Log(other.name);
			GameObject shipToAdd = other.gameObject;
			
			if(squadron.SquadronListHasEmptySlot() && !squadron.ShipAlreadyInSquadron(shipToAdd))
			{
				Debug.Log("Ship not in squadron");
				squadron.SetOpenSlot(squadron.FindNextOpenSlot(),shipToAdd);
				SquadronFighter temp = shipToAdd.GetComponent<SquadronFighter>();
				temp.RemoveNaviMesh();
				temp.gameObject.layer = LayerMask.NameToLayer("Allies");
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
