using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldArr : MonoBehaviour
{
   public List<GameObject> shields = new List<GameObject>();

   public void OnDeath(GameObject obj)
   {
      shields.Remove(obj);
      if (shields.Count < 1)
      {
         //Disable overall shield
      }
   }
   
}
