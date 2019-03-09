using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySquadron : MonoBehaviour
{
    //randomly spawns and generates circular motion
    float speed = 5f;
    float randXRad;
    float randZRad;
    float randX;
    float randY;
    float randZ;

    private void Start()
    {
        randX = Random.Range(0f, 100f);
        randXRad = Random.Range(-100f, 100f);
        randY = Random.Range(-10f, 10f);
        randZ = Random.Range(0f, 1000f);
        randZRad = Random.Range(-100f, 100f);
    }
    void Update()
    {
        speed += Time.deltaTime;
        float x = randX + (randXRad * Mathf.Cos(speed));
        float z = randZ + (randZRad * Mathf.Sin(speed));
        transform.position = new Vector3(x, randY, z);
    }

}
