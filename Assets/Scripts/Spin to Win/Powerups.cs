using System.Collections;
using System.Collections.Generic;
using Codice.CM.Common;
using UnityEngine;
using UnityEngine.UIElements;

public class Powerups : MonoBehaviour
{
    public GameObject powerupPrefab; 
    public int powerups = 5;
    public float radius = 5f; 
    public float orbitSpeed = 10f; 

    private List<GameObject> powerupInstances = new List<GameObject>();
    public float[] angles; 

    void Start()
    {
        angles = new float[powerups];
        SpawnPowerups();
    }

    void Update()
    {
        OrbitPowerups();
        CheckForRemovePowerup();
    }

    public void SpawnPowerups()
    {
        float angleStep = 360f / powerups;

        for (int i = 0; i < powerups; i++)
        {
            angles[i] = i * angleStep * Mathf.Deg2Rad;

            float x = Mathf.Cos(angles[i]) * radius;
            float y = Mathf.Sin(angles[i]) * radius;

            Vector3 powerupPos = new Vector3(x, y); 

            GameObject powerupInstance = Instantiate(powerupPrefab, powerupPos, Quaternion.identity);
            powerupInstances.Add(powerupInstance);
        }
    }

    private void OrbitPowerups()
    {
        Vector3 orbitCenter = transform.position; 

        for (int i = 0; i < powerupInstances.Count; i++)
        {
            angles[i] += orbitSpeed * Time.deltaTime * Mathf.Deg2Rad;

            Vector3 direction = new Vector3(Mathf.Cos(angles[i]), Mathf.Sin(angles[i])) * radius;
            powerupInstances[i].transform.position = orbitCenter + direction;
        }
    }

    private void CheckForRemovePowerup()
    {
        if (Input.GetKeyDown(KeyCode.C) && powerupInstances.Count > 0)
        {
            GameObject powerupToRemove = powerupInstances[powerupInstances.Count - 1];
            powerupInstances.RemoveAt(powerupInstances.Count - 1);
            Destroy(powerupToRemove);
        }
    }
}
