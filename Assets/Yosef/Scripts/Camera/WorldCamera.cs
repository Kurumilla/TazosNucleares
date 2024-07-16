using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldCamera : MonoBehaviour
{
    private Vector3 pos;
    public float distance;
    public float angle;

    void Start()
    {
        pos.x = 0;
        pos.y = Mathf.Sin(angle * Mathf.Deg2Rad) * distance;
        pos.z = Mathf.Cos(angle * Mathf.Deg2Rad) * -distance;
        transform.localPosition = pos;
    }

    void Update()
    {
        if (ObstructionFromView())
        {
            transform.localPosition = new Vector3(0, distance, 0);
            transform.eulerAngles = new Vector3(90f, 0, 0);
        }
        else
        {
            transform.localPosition = pos;
            transform.eulerAngles = new Vector3(angle, 0, 0);
        }
    }

    //Checks if there is a clear path from the player to the camera
    bool ObstructionFromView()
    {
        RaycastHit hit;
        if (Physics.Raycast(transform.parent.position, pos, out hit, distance))
        {
            if (hit.transform.gameObject.tag != "Player")
            {
                return AreYouSure();
            }
        }
        return false;
    }

    //Cancels the top-view order, in case it was just a small obstruction like a lightpole
    bool AreYouSure()
    {
        for (float j=-0.5f; j<1; j++)
        {
            for (float k=-0.5f; k<1; k++)
            {
                Vector3 offset = new Vector3(j, k, 0);
                if (!Physics.Raycast(transform.parent.position + offset, pos, distance))
                    return false;
            }
        }
        return true;
    }
}
