using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Missile : MonoBehaviour
{
    public Vector3 target;
    public float missileSpeed;
    Rigidbody rb;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        Physics.IgnoreLayerCollision(LayerMask.NameToLayer("Missile"),LayerMask.NameToLayer("Shield"));
    }
    void Update()
    {
        SlerpLookAt();
    }
    void FixedUpdate()
    {
        MoveForward();
    }

    void MoveForward()
    {
        rb.AddForce(transform.forward * missileSpeed * Time.deltaTime ,ForceMode.Impulse);
    }
    void SlerpLookAt()
    {
        Quaternion lookOnLook = Quaternion.LookRotation(target,transform.position);
        transform.rotation = Quaternion.Slerp(transform.rotation, lookOnLook, 5*Time.deltaTime);
    }

}
