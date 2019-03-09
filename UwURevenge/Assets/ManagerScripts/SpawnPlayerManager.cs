using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPlayerManager : MonoBehaviour
{
    public static SpawnPlayerManager instance;
    public GameObject prefabToSpawn;
    public Transform spawnPosition;
    public ObjectFollow mainCamera;
    public ObjectFollow squadron;

    void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(this);
        }
        
    }

    void OnEnable()
    {
        SpawnPlayer();
        SetMainCameraPosition();
        SetMainCameraTarget();
        SetSquadronPosition();
        SetSquadronTarget();
    }


    void SpawnPlayer()
    {
        prefabToSpawn = SceneChanger.instance.player;
        prefabToSpawn.transform.position = spawnPosition.position;
        prefabToSpawn.transform.rotation = spawnPosition.rotation;
        prefabToSpawn.SetActive(true);
    }

    void SetMainCameraTarget()
    {
        mainCamera.target = prefabToSpawn.transform;
    }

    void SetSquadronTarget()
    {
        squadron.target = prefabToSpawn.transform;
    }

    void SetMainCameraPosition()
    {
        mainCamera.transform.rotation = spawnPosition.rotation;
        mainCamera.transform.position = spawnPosition.position;

        mainCamera.transform.position = prefabToSpawn.transform.forward * -40;
    }

    void SetSquadronPosition()
    {
        squadron.transform.rotation = spawnPosition.rotation;
        squadron.transform.position = spawnPosition.position;

        squadron.transform.position = prefabToSpawn.transform.forward * 10;
    }
}
