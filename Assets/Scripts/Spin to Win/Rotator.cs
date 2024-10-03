using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotator : MonoBehaviour
{
    public float rotateSpeed = 5f;
    public float radius = 1f;

    float currentAngle = 0f;

    public Transform planet;

    void Start()
    {
        
    }

    void Update()
    {
        OrbitalMotion();
    }

    public void OrbitalMotion()
    {
        currentAngle += rotateSpeed * Time.deltaTime;

        float angleToRad = currentAngle * Mathf.Deg2Rad;

        float x = planet.position.x + Mathf.Cos(angleToRad) * radius;
        float y = planet.position.y + Mathf.Sin(angleToRad) * radius;

        transform.position = new Vector3(x, y);
    }
}
