using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PersistAcrossSceneChange : MonoBehaviour
{
    void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }
}
