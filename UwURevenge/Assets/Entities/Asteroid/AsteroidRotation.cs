using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidRotation : Entity
{

    public float speed;
    public float distance;
    public float maxDistance;
    
    public GameObject spawnObjectOnDeath; 
    private Vector3 randDir;
    private Vector3 randRot;
    
    // Start is called before the first frame update 
    void Start() 
    { 
        randDir = new Vector3(Random.Range(-1f, 1f), Random.Range(-1f, 1f), Random.Range(-1f, 1f)); 
        randRot = new Vector3(Random.Range(-1f, 1f), Random.Range(-1f, 1f), Random.Range(-1f, 1f));

        distance = 0;
        maxDistance = Random.Range(1000, 2000);
    } 
 
    // Update is called once per frame 
    void Update()
    {
        float delta = speed * Time.deltaTime;
        distance += delta;
        if (distance >= maxDistance)
        {
            randDir = -randDir;
            distance = 0;
        }
        
        transform.position += randDir * delta;

        float rx = randRot.x * speed * Time.deltaTime;
        float ry = randRot.y * speed * Time.deltaTime;
        float rz = randRot.z * speed * Time.deltaTime;
        
        Vector3 newRot = new Vector3(rx, ry, rz); 
        transform.Rotate(newRot); 
    } 
 
    public override void Die()
    {
        if (deathEffect != null) 
        { 
            Instantiate(deathEffect, transform.position, Quaternion.identity); 
        }

        if (spawnObjectOnDeath != null)
        {
            Instantiate(spawnObjectOnDeath, transform.position, Quaternion.identity); 
        }

        Destroy(gameObject);
    } 
}
