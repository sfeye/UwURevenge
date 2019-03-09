using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour
{
    public static SceneChanger instance;
    public GameObject playerPrefabChosen;
    public GameObject player;
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

    public void StartSpaceBattle()
    {
        playerPrefabChosen = ShipSelectionManager.instance.playerPrefabs[ShipSelectionManager.instance.currIndex];
        player = Instantiate(playerPrefabChosen,transform.position,Quaternion.identity);
        player.SetActive(false);
        SceneManager.LoadScene(1);
        
    }
}
