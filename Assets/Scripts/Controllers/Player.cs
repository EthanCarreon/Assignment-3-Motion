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
    float acceleration;

    void Start()
    {
        acceleration = maxSpeed / accelerationTime;
    }

    void Update()
    {

        PlayerMovement();
    }

    void PlayerMovement()
    {
        // Task 1A

        Vector3 movement = new Vector3(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical")).normalized;

        // Task 1B

        if (movement.magnitude > 0)
        {
            currentSpeed = currentSpeed + acceleration * Time.deltaTime;

            if (currentSpeed > maxSpeed)
            {
                currentSpeed = maxSpeed;
            }
        }
        else
        {
            currentSpeed -= acceleration * Time.deltaTime;

            if (currentSpeed < 0)
            {
                currentSpeed = 0;
            }
        }

        Vector3 velocity = movement * currentSpeed;
        transform.position += velocity * Time.deltaTime;

    }

}
