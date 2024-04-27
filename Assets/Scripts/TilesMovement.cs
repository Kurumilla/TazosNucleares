using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TilesMovement : MonoBehaviour
{
    public float moveSpeed = 5.0f;
    public Transform movePoint;

    void Start()
    {
        movePoint.parent = null;
    }

    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, movePoint.position, moveSpeed * Time.deltaTime);

        if(Vector3.Distance(transform.position, movePoint.position) <= 0.05f)
        {
            if (Mathf.Abs(Input.GetAxisRaw("Horizontal")) == 1.0f)
            {
                movePoint.position -= new Vector3(0.0f, 0.0f, Input.GetAxisRaw("Horizontal"));
            }

            if (Mathf.Abs(Input.GetAxisRaw("Vertical")) == 1.0f)
            {
                movePoint.position += new Vector3(Input.GetAxisRaw("Vertical"), 0.0f, 0.0f);
            }
        }
    }
}
