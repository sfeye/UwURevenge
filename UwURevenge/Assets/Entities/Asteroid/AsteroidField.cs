using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidField : MonoBehaviour
{

    public int sizeX;
    public int sizeY;
    public int sizeZ;

    public int density;

    public GameObject[] rocks;
    
    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < density; i++)
        {
            int index = Random.Range(0, rocks.Length);

            float px = transform.position.x + Random.Range(-sizeX, sizeX);
            float py = transform.position.y + Random.Range(-sizeY, sizeY);
            float pz = transform.position.z + Random.Range(-sizeZ, sizeZ);

            float rx = Random.Range(0f, 359f);
            float ry = Random.Range(0f, 359f);
            float rz = Random.Range(0f, 359f);
            
            GameObject obj = Instantiate(rocks[index], new Vector3(px, py, pz), Quaternion.Euler(rx, rz, ry));
            obj.transform.localScale *= Random.Range(2f, 5f);
        }
    }

}
