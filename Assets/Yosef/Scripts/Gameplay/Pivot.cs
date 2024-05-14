// Camera moves in a half-sphere shape around the playground to provide multiple points of view.
// Place in the Camera's parent

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pivot : MonoBehaviour
{
    [Header("Main Settings")]
    public bool active = true;
    public float speed = 10f;
    public float radius = 1f;
    public Vector3 center;
    public Vector2 clamps;

    [Header("Current Position (in angles)")]
    public float clockwisePosition = 0f;
    public float distanceFromCenter = 0f;

    void Update()
    {
        if (active)
        {
            // Modify variables
            clockwisePosition += Input.GetAxis("Horizontal") * speed * Time.deltaTime;
            distanceFromCenter -= Input.GetAxis("Vertical") * speed * Time.deltaTime;
            distanceFromCenter = Mathf.Clamp(distanceFromCenter, clamps.x, clamps.y);   //No going around the top or under the floor.

            // Slot variables into 0-1 range
            float phi = clockwisePosition / 57.45f;
            float theta = distanceFromCenter / 50f;

            // Apply changes to world
            float x = Mathf.Cos(phi) * Mathf.Sin(theta) * radius;
            float y = Mathf.Cos(theta) * radius;
            float z = Mathf.Sin(phi) * Mathf.Sin(theta) * radius;
            transform.position = new Vector3(x, y, z) + center;

            // Rotate back into the playground
            transform.LookAt(Vector3.zero);
        }
    }

    public void SetMode(bool _active)
    {
        active = _active;
    }
}
