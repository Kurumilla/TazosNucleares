using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AI_Turn : MonoBehaviour
{
    public List<GameObject> enemyTazos;

    void Start()
    {
        
    }

    public void AI_Shoot()
    {
        if (enemyTazos.Count == 0)
            return;

        GameObject[] board = GameObject.FindGameObjectsWithTag("Tazo");
        Vector3 pos = new Vector3(0, 5f, 0);
        Vector3 rot = new Vector3(89.5f, 0, 0);

        if (board[0] != gameObject)
            pos += board[0].transform.position;
        else
            pos += board[1].transform.position;

        GameObject token = (GameObject)Instantiate(enemyTazos[0], pos, Quaternion.Euler(rot));
        enemyTazos.RemoveAt(0);
    }
}
