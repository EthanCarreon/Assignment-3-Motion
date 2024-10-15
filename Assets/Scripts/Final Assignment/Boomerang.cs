using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boomerang : MonoBehaviour
{
    public Transform player;
    public GameObject boomerang;
    public float radius = 5f;
    public float speed = 180f;

    Vector2 offset = new Vector2(-2f, 0f);

    bool isOrbiting = false;
    float angle = 0f;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.B) && !isOrbiting)
        {
            isOrbiting = true;
            angle = 0f;
            boomerang.SetActive(true);
        }

        if (isOrbiting)
        {
            OrbitBoomerang();

            if (angle >= 360f)
            {
                isOrbiting = false;
                boomerang.SetActive(false);
                PositionBoomerang();
            }
        }
    }

    public void PositionBoomerang()
    {
        Vector2 initialPosition = (Vector2)player.position + offset;
        boomerang.transform.position = new Vector3(initialPosition.x, initialPosition.y);
    }

    public void OrbitBoomerang()
    {
        angle += speed * Time.deltaTime;

        float angleToRad = angle * Mathf.Deg2Rad;

        float x = Mathf.Cos(angleToRad) * radius;
        float y = Mathf.Sin(angleToRad) * radius;

        Vector2 centerPosition = new Vector2(player.position.x, player.position.y) + offset;

        boomerang.transform.position = new Vector3(centerPosition.x + x, centerPosition.y + y);
    }
}