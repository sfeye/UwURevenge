using System.Collections;

using System.Collections.Generic;

using UnityEngine;



public class EnemyMove : MonoBehaviour

{

    //randomly spawns and generates circular motion
    public float rotationCorrectionSpeed = 5f;
    public float rotationSpeed = 50.0f;
    public float bankRotationSpeed = 60f;
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
        Vector3 newPos = new Vector3(x, randY, z);
        transform.LookAt(newPos);
        EnemyRotate();
        transform.position = newPos;
        RotateToOrigin();
    }
    void EnemyRotate()
    {
        float rotateZ = (bankRotationSpeed * Mathf.Abs(Mathf.Sin(speed))) * (-1f);
        Vector3 bankRotation = new Vector3(0f, 0f, rotateZ);
        transform.Rotate(bankRotation);

    }
    void RotateToOrigin()
    {
        var newRotation = Quaternion.Euler(0f, transform.eulerAngles.y, 0f);
        transform.rotation = Quaternion.Slerp(transform.rotation, newRotation, rotationCorrectionSpeed * Time.deltaTime);
    }
}
