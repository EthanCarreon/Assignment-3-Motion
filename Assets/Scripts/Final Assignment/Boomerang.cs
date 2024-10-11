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

            if (angle >= 2 * Mathf.PI)
            {
                isOrbiting = false;
                boomerang.SetActive(false);
            }
        }
    }

    public void OrbitBoomerang()
    {
        angle += speed * Time.deltaTime * Mathf.Deg2Rad;

        Vector3 orbitCenter = (Vector2)player.position + offset;

        Vector3 direction = new Vector3(Mathf.Cos(angle), Mathf.Sin(angle)) * radius;

        boomerang.transform.position = orbitCenter + direction;
    }
}
