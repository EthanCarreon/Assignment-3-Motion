using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidDetector : MonoBehaviour
{
    public Transform asteroid;

    bool isMoving = false;

    public float asteroidDist = 0f;
    public float asteroidDuration = 5f;

    Vector3 startPos;
    Vector3 endPos;
    void Start()
    {
        startPos = asteroid.position;
        endPos = transform.position;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.T))
        {
            isMoving = true;
            asteroidDist = 0f;
            startPos = asteroid.position;
            endPos = transform.position;
        }

        if (isMoving)
        {
            asteroidDist += Time.deltaTime / asteroidDuration;

            if (asteroidDist > 1f)
            {
                asteroidDist = 1f;
                isMoving = false;
            }

            asteroid.position = Vector3.Lerp(startPos, endPos, asteroidDist);
        }

    }
}

