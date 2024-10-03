using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Powerups : MonoBehaviour
{
    public int powerups = 6;
    public float radius = 5f;

    public GameObject powerupPrefab;

    private void Start()
    {
        SpawnPowerups();
    }

    void Update()
    {
        
    }

    public void SpawnPowerups()
    {
        float angles = 360f / powerups;

        for (int i = 0; i < powerups; i++)
        {
            float angle = i * angles * Mathf.Deg2Rad;

            float x = transform.position.x + Mathf.Cos(angle) * radius;
            float y = transform.position.y + Mathf.Sin(angle) * radius;

            Vector3 powerupPos = new Vector3(x, y);

            Instantiate(powerupPrefab, powerupPos, Quaternion.identity);
        }
    }
}
