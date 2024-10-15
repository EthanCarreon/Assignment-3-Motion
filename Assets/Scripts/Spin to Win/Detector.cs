using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Detector : MonoBehaviour
{
    public int circleSides = 6;
    public float radius = 5f;

    public Transform enemy;

    public List<Transform> asteroids = new List<Transform>();

    public float asteroidSpeed = 1f;
    public float asteroidDuration = 5f;

    private List<Vector3> startPositions = new List<Vector3>();
    private List<Vector3> endPositions = new List<Vector3>();
    private List<float> asteroidDistances = new List<float>();
    private List<bool> isMoving = new List<bool>();

    void Start()
    {
        for (int i = 0; i < asteroids.Count; i++)
        {
            startPositions.Add(asteroids[i].position);
            endPositions.Add(transform.position);
            asteroidDistances.Add(0f);
            isMoving.Add(false);
        }
    }

    void Update()
    {
        EnemyRadar();

        for (int i = 0; i < asteroids.Count; i++)
        {
            if (isMoving[i])
            {
                asteroidDistances[i] += Time.deltaTime / asteroidDuration;

                if (asteroidDistances[i] > 1f)
                {
                    asteroidDistances[i] = 1f;
                    isMoving[i] = false;
                }

                asteroids[i].position = Vector3.Lerp(startPositions[i], endPositions[i], asteroidDistances[i]);
            }
        }
    }

    void EnemyRadar()
    {
        float angleCount = 360f / circleSides;
        Vector3 prevPointPos = Vector3.zero;

        for (int i = 0; i <= circleSides; i++)
        {
            float angle = i * angleCount * Mathf.Deg2Rad;

            float x = transform.position.x + Mathf.Cos(angle) * radius;
            float y = transform.position.y + Mathf.Sin(angle) * radius;

            Vector3 linePos = new Vector3(x, y);

            if (i == 0)
            {
                prevPointPos = linePos;
            }

            bool asteroidInRange = false;

            for (int j = 0; j < asteroids.Count; j++)
            {
                float asteroidDist = Vector3.Distance(transform.position, asteroids[j].position);

                if (asteroidDist <= radius)
                {
                    asteroidInRange = true;

                    isMoving[j] = true;
                    asteroidDistances[j] = 0f;
                    startPositions[j] = asteroids[j].position;
                    endPositions[j] = transform.position;
                }
            }

            if (asteroidInRange)
            {
                Debug.DrawLine(prevPointPos, linePos, Color.red);
            }
            else
            {
                Debug.DrawLine(prevPointPos, linePos, Color.green);
            }

            prevPointPos = linePos;
        }
    }
}