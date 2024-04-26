// Camera moves in a half-sphere shape around the playground to provide multiple points of view.
// Place in the Camera's parent

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pivot : MonoBehaviour
{
    Vector3 startingPos;

    [Header("Main Settings")]
    public bool active = true;
    public float speed = 10f;
    public float radius = 1f;

    [Header("Current Position (in angles)")]
    public float clockwisePosition = 0f;
    public float distanceFromCenter = 0f;

    void Start()
    {
        startingPos = transform.position;
    }

    void Update()
    {
        if (active)
        {
            // Modify variables
            clockwisePosition += Input.GetAxis("Horizontal") * speed * Time.deltaTime;
            distanceFromCenter -= Input.GetAxis("Vertical") * speed * Time.deltaTime;
            distanceFromCenter = Mathf.Clamp(distanceFromCenter, 1f, 90f);   //No going around the top or under the floor.

            // Slot variables into 0-1 range
            float s = clockwisePosition / 360;
            float t = distanceFromCenter / 90f;

            // Apply changes to world
            float x = Mathf.Cos(s) * Mathf.Sin(t) * radius;
            float y = Mathf.Cos(t) * radius;
            float z = Mathf.Sin(s) * Mathf.Sin(t) * radius;
            transform.position = new Vector3(x, y, z) + startingPos;

            // Rotate back into the playground
            transform.LookAt(Vector3.zero);
        }
    }
}
