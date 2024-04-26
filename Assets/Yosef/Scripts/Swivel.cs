// Camera tilts around to the player's liking. used for aiming.
// Place in the Camera

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Swivel : MonoBehaviour
{
    public float speed = 10f;
    public bool active = false;

    [Header("Swivel Settings")]
    public float rotationLimit = 30f;
    public Vector3 currentRot;

    void Start()
    {
        currentRot = transform.localEulerAngles;
    }

    void Update()
    {
        if (active)
        {
            // Get input values
            currentRot.y += Input.GetAxis("Horizontal") * speed * Time.deltaTime;
            currentRot.x -= Input.GetAxis("Vertical") * speed * Time.deltaTime;

            // Clamps
            currentRot.y = Mathf.Clamp(currentRot.y, -rotationLimit, rotationLimit);
            currentRot.x = Mathf.Clamp(currentRot.x, -rotationLimit, rotationLimit);

            transform.localEulerAngles = currentRot;
        }
    }
}
