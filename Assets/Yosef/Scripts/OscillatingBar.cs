using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OscillatingBar : MonoBehaviour
{
    public float speed = 1f;
    public float value = 0f;
    private bool growing = true;

    Material mat;

    void Start()
    {
        mat = GetComponent<Renderer>().material;
    }

    void Update()
    {
        // Oscillate value
        if (growing)
            value += speed * Time.deltaTime;
        else
            value -= speed * Time.deltaTime;

        // Flip sides
        if (growing && value >= 1)
        {
            growing = false;
            value = 1;
        }
        else if (!growing && value <= 0)
        {
            growing = true;
            value = 0;
        }

        // Apply to bar
        mat.SetFloat("_Progress", value);
    }
}
