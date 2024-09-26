using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour
{
    public float speed = 5f;
    public float dashSpeed = 10f;
    public float dashDistance = 5f;

    Vector3 lastDirection;
    bool isDashing = false;

    Vector3 targetPos;

    void Update()
    {
        EnemyMovement();
    }

    void EnemyMovement()
    {
        Vector3 movement = new Vector3(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical")).normalized;

        if (movement.magnitude > 0)
        {
            lastDirection = movement;
        }

        transform.position += movement * speed * Time.deltaTime;

        if (Input.GetKeyDown(KeyCode.Space) && !isDashing)
        {
            isDashing = true;
            targetPos = transform.position + lastDirection * dashDistance;
            
        }

        if (isDashing)
        {
            transform.position = Vector3.Lerp(transform.position, targetPos, speed * Time.deltaTime);

            if (Vector3.Distance(transform.position, targetPos) < 0.1f)
            {
                isDashing = false;
            }
        }
    }

}

