using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public List<Transform> asteroidTransforms;
    public Transform enemyTransform;
    public GameObject bombPrefab;
    public Transform bombsTransform;

    public float maxSpeed = 5f;
    public float currentSpeed = 0f;
    public float accelerationTime = 3f;
    public float decelerationTime = 2f;
    float acceleration;
    float deceleration;

    Vector3 lastPos;
    void Start()
    {
        acceleration = maxSpeed / accelerationTime;
        deceleration = maxSpeed / decelerationTime;
    }

    void Update()
    {

        PlayerMovement();
    }

    void PlayerMovement()
    {
        // Task 1A

        Vector3 movement = new Vector3(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical")).normalized;

        // Task 1B & 1C

        if (movement.magnitude > 0)
        {
            currentSpeed += acceleration * Time.deltaTime;

            if (currentSpeed > maxSpeed)
            {
                currentSpeed = maxSpeed;
            }

            lastPos = movement;
        }
        else
        {
            currentSpeed -= deceleration * Time.deltaTime;

            if (currentSpeed < 0)
            {
                currentSpeed = 0;
            }
        }

        Vector3 velocity = lastPos * currentSpeed;
        transform.position += velocity * Time.deltaTime;

    }

    public void EnemyMovement()
    { 
    }

}
