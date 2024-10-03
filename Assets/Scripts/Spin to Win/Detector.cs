using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Detector : MonoBehaviour
{
    public int circleSides = 6;
    public float radius = 5f;

    public Transform enemy;
    void Start()
    {
        
    }

    
    void Update()
    {
        EnemyRadar();
    }

    void EnemyRadar()
    {
        float angleCount = 360f / circleSides;

        float enemyDist = Vector3.Distance(transform.position, enemy.position);

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

            if (enemyDist <= radius)
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
