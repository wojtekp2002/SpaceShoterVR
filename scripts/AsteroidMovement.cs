using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidMovement : MonoBehaviour
{
    [Header("Control the speed of the Asteroid")]
    public float maxSpeed;
    public float minSpeed;

    [Header("Control the rotational speed")]
    public float rotationalSpeedMin;
    public float rotationalSpeedMax;

    private float rotationalSpeed;
    private float xAngle, yAngle, zAngle;

    public Vector3 movementDirection;

    private float asteroidSpeed;

    void Start()
    {
        asteroidSpeed = Random.Range(minSpeed, maxSpeed);

        xAngle = Random.Range(0, 360);
        yAngle = Random.Range(0, 360);
        zAngle = Random.Range(0, 360);

        transform.Rotate(xAngle, yAngle, zAngle);

        rotationalSpeed = Random.Range(rotationalSpeedMin, rotationalSpeedMax);

    }

    void Update()
    {
        transform.Translate(movementDirection * Time.deltaTime * asteroidSpeed, Space.World);
        transform.Rotate(Vector3.up * Time.deltaTime * rotationalSpeed);
    }
}
