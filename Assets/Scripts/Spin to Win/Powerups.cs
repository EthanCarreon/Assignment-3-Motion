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

    Vector3 startShootPos;
    Vector3 endShootPos;
    Vector3 offset = new Vector3(0, 15);

    bool isShooting = false;

    public float bulletDist = 0f;
    public float bulletDuration = 0f;
    public float bulletSpeed = 2f;

    public GameObject bullet;
    void Start()
    {
        startShootPos = transform.position;
        endShootPos = transform.position + offset;

        angles = new float[powerups];
        SpawnPowerups();

        bullet.SetActive(false);
    }

    void Update()
    {
        OrbitPowerups();
        CheckForRemovePowerup();

        if (Input.GetKeyDown(KeyCode.C) && !isShooting)
        {
            startShootPos = transform.position;
            endShootPos = startShootPos + offset;
            isShooting = true;
            bullet.SetActive(true);
        }

        if (isShooting)
        {
            bulletDist += Time.deltaTime * bulletSpeed;
            bullet.transform.position = Vector3.Lerp(startShootPos, endShootPos, bulletDist);

            if (bulletDist >= 1f)
            {
                isShooting = false;
                bulletDist = 0f;
                bullet.SetActive(false);
            }  
        }
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
        for (int i = 0; i < powerupInstances.Count; i++)
        {
            angles[i] += orbitSpeed * Time.deltaTime * Mathf.Deg2Rad;

            Vector3 orbitCenter = (Vector2)transform.position;
            powerupInstances[i].transform.RotateAround(transform.position, Vector3.forward, orbitSpeed * Time.deltaTime);

            Vector3 direction = new Vector3(Mathf.Cos(angles[i]), Mathf.Sin(angles[i])) * radius;
            powerupInstances[i].transform.position = orbitCenter + direction;
        }
    }

    private void CheckForRemovePowerup()
    {
        if (Input.GetKeyDown(KeyCode.C) && powerupInstances.Count > 0 && !isShooting)
        {
            GameObject powerupToRemove = powerupInstances[powerupInstances.Count - 1];

            powerupInstances.Remove(powerupToRemove); 
            Destroy(powerupToRemove);

            RefreshAngles();
        }
    }

    private void RefreshAngles()
    {
        int count = powerupInstances.Count; 
        angles = new float[count]; 

        float angleStep = 360f / count; 

        for (int i = 0; i < count; i++)
        {
            angles[i] = i * angleStep * Mathf.Deg2Rad; 
        }
    }
}