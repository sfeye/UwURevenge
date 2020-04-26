using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPickup : MonoBehaviour
{
    public Entity player;

    private void Start()
    {
        player = GetComponent<Entity>();
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.tag == "pickup")
        {
            if (player.currHealth >= player.maxHealth)
                player.currHealth = player.maxHealth;
            else
                player.currHealth += 10f;
            Destroy(collision.gameObject);
        }
    }
}
