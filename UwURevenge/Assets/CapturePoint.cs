using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CapturePoint : MonoBehaviour
{
    public float currCapture = 0f;
    public float maxCapture = 100f;
    public GameObject captureEffect;
    public Material captureMaterial;
    public GameObject OrbitalStation;
    public GameObject NaviMesh;
    public Renderer osR;
    public Renderer nmR;
    

    void Start()
    {
        osR = OrbitalStation.GetComponent<Renderer>();
        nmR = NaviMesh.GetComponent<Renderer>();
    }
    void OnTriggerStay(Collider other)
    {
        if(other.tag == "player")
        {
            IncrementCapturePoints();
        }
    }

    void IncrementCapturePoints()
    {
        currCapture += Time.deltaTime * 10f;
        if(currCapture >= maxCapture)
        {
            Capture();
        }
    }

    void Capture()
    {
        GetComponent<SphereCollider>().enabled = false;

        Material[] materials = osR.materials;
        materials[1] = captureMaterial;
        osR.materials = materials;

        materials = nmR.materials;
        materials[0] = captureMaterial;
        nmR.materials = materials;

        Instantiate(captureEffect,transform.position,Quaternion.identity);
    }
}
