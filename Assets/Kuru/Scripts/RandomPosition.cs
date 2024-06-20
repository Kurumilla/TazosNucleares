using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomPosition : MonoBehaviour
{
    public float altura = 0.28f;
    void Start()
    {
        float randomX = Random.Range(-0.45f, 0.45f);
        float randomZ = Random.Range(-0.45f, 0.45f);
        transform.position = new Vector3(randomX, altura, randomZ);

        //if (area != null)
        //{


        //    //Vector3 size = area.size;
        //    //Vector3 center = area.center;

        //    //float minX = center.x - size.x / 2f;
        //    //float maxX = center.x + size.x / 2f;
        //    //float minZ = center.z - size.z / 2f;
        //    //float maxZ = center.z + size.z / 2f;

        //    float randomX = Random.Range(minX, maxX);
        //    float randomZ = Random.Range(minZ, maxZ);

        //    transform.position = new Vector3(randomX, height, randomZ) + area.transform.position;
        //}
        //else
        //{
        //    Debug.LogWarning("No se ha asignado un BoxCollider al script");
        //}
    }
}
