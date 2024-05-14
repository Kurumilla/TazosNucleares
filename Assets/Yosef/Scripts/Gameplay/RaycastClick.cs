using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaycastClick : MonoBehaviour
{
    Camera cam;
    public LayerMask mask;

    void Start()
    {
        cam = Camera.main;
    }

    void Update()
    {
        Vector3 mousePos = Input.mousePosition;
        mousePos.z = 100f;
        mousePos = cam.ScreenToWorldPoint(mousePos);

        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = cam.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, 100, mask))
                hit.transform.GetComponent<Tazo>().OnClick();
        }
    }
}
