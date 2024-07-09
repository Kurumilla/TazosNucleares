using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC_LookAt : MonoBehaviour
{
    public Transform camera;

    void Update()
    {
        transform.LookAt(camera);
        Vector3 rot = transform.eulerAngles;
        rot.z = 0;
        transform.eulerAngles = rot;
    }
}
