using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stars : MonoBehaviour
{
    public List<Transform> starTransforms;
    public float drawingTime;
    float currentTime = 0f;

    int currentStartStar = 0;
    int currentEndStar = 1;

    void Update()
    {
        DrawConstellation();
    }

    void DrawConstellation()
    {
        currentTime += Time.deltaTime;
        float t = currentTime / drawingTime;

        Vector3 endPoint = Vector3.Lerp(starTransforms[currentStartStar].position, starTransforms[currentEndStar].position, t);

        Debug.DrawLine(starTransforms[currentStartStar].position, endPoint, Color.white);

        if (t >= 1f)
        {
            currentStartStar = currentEndStar;
            currentEndStar++;

            currentTime = 0f;
        }

        if (currentEndStar >= starTransforms.Count)
        {
            currentEndStar = 1;
            currentStartStar = 0;
        }

        
    }
}
