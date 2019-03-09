using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BreakableAsteroid : Entity
{
    public float speed;
    public GameObject spawnObjectOnDeath;
    private Vector3 randDir;
    // Start is called before the first frame update
    void Start()
    {
        randDir = new Vector3(Random.Range((float)-1f, (float) 1f), Random.Range((float)-1f, (float)1f), Random.Range((float)-1f, (float)1f));
    }

    // Update is called once per frame
    void Update()
    {
        Rotate();
        MoveAsteroid(speed);
    }

    void MoveAsteroid (float _speed)
    {
        transform.position = transform.position + (randDir * (_speed/100) * Time.deltaTime);
    }

    void Rotate()
    {
        Vector3 newRot = new Vector3(0,speed * Time.deltaTime,0);
        transform.Rotate(newRot);
    }

    void DropMaterial ()
    {
        Instantiate(spawnObjectOnDeath,transform.position,Quaternion.identity);

    }

    public override void Die()
    {
        if (deathEffect != null)
        {
            Instantiate(deathEffect, transform.position, Quaternion.identity);
        }
        DropMaterial();
        Destroy(gameObject);
    }
}
