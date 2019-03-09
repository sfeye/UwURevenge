using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipSelectionManager : MonoBehaviour
{
    public static ShipSelectionManager instance;
    public  GameObject[] playerShips;
    public  GameObject[] playerPrefabs;
    public  GameObject currentShipDisplayed;
    public int  currIndex = 0;

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

    void Start()
    {
        currentShipDisplayed = playerShips[currIndex];
        currentShipDisplayed.SetActive(true);
    }
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.A))
        {
            DeactivateCurrentShip();
            CycleShip((int) -1);
            ShowCurrentShip();
        }
        else if(Input.GetKeyDown(KeyCode.D))
        {
            DeactivateCurrentShip();
            CycleShip((int) 1);
            ShowCurrentShip();
        }

        if(Input.GetKeyDown(KeyCode.KeypadEnter))
        {
            SceneChanger.instance.StartSpaceBattle();
        }

        
    }

    void CycleShip(int increment)
    {
        currIndex += increment;
        if(currIndex >= playerShips.Length)
        {
            currIndex = 0;
        }
        else if(currIndex < 0)
        {
            currIndex = playerShips.Length - 1;
        }

        SetCurrentShip(currIndex);
    }

    void SetCurrentShip(int index)
    {
        currentShipDisplayed = playerShips[currIndex];
    }

    void DeactivateCurrentShip()
    {
        currentShipDisplayed.SetActive(false);
    }

    void ShowCurrentShip()
    {
        currentShipDisplayed.SetActive(true);
    }
}
