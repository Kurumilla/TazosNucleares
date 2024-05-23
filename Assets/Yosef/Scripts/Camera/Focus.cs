using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Focus : MonoBehaviour
{
    [Header("Main Settings")]
    public float speed;
    public float distance;
    public float progress = 0f;

    [Header("Focus Settings")]
    private Vector3 startingPos, targetPos;
    private Quaternion startingRot, targetRot;

    public bool CameraMovement(int multiplier)
    {
        if (progress < 0) { return true; }
        else if (progress <= 1)
        {
            progress += speed * multiplier * Time.deltaTime;
            progress = Mathf.Clamp(progress, -0.1f, 1f);
            transform.position = Vector3.Lerp(startingPos, targetPos, progress);
            transform.rotation = Quaternion.Slerp(startingRot, targetRot, progress);
        }
        return false;
    }

    public void SetVariables(Transform _target)
    {
        progress = 0;
        startingPos = transform.position;
        startingRot = transform.rotation;
        targetPos = _target.position + Vector3.Normalize(_target.position) * distance;
        targetRot = Quaternion.LookRotation(_target.position - targetPos, Vector3.up);
    }
}
