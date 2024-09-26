using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Asteroid : MonoBehaviour
{
    public float moveSpeed;
    public float arrivalDistance;
    public float maxFloatDistance;

    Vector3 targetPos;

     public List<Transform> asteroids;

    void Start()
    {
        RandomPosition();
    }

    void Update()
    {
        AsteroidMovement();
    }

    void AsteroidMovement()
    {
            transform.position = Vector3.Lerp(transform.position, targetPos, moveSpeed * Time.deltaTime);

            if (Vector3.Distance(transform.position, targetPos) <= arrivalDistance)
            {
                RandomPosition();
            }
    }

    void RandomPosition()
    {
        float x = Random.Range(-maxFloatDistance, maxFloatDistance);
        float y = Random.Range(-maxFloatDistance, maxFloatDistance);

        targetPos = new Vector3(transform.position.x + x, transform.position.y + y);
    }


}
