using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkyboxGen : MonoBehaviour
{


    public Material[] mats;
    
    // Start is called before the first frame update
    void Start()
    {
        int index = Random.Range(0, mats.Length);
        RenderSettings.skybox = mats[index];
    }
}
