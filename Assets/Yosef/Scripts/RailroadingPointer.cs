using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RailroadingPointer : MonoBehaviour
{
    public float distanceToHide = 10f;

    // Object References
    private Transform player;
    private List<Vector3> enemiesLeft = new List<Vector3>();

    // UI References
    public RectTransform pointerPos, pointerRot;
    private RectTransform canvas;

    void Start()
    {
        // Resize
        canvas = FindObjectOfType<Canvas>().GetComponent<RectTransform>();
        pointerPos.sizeDelta = new Vector2(canvas.rect.height / 4f, canvas.rect.height / 4f);

        // Add to the list the enemies you havent beat yet
        player = GameObject.FindWithTag("Player").transform;
        GameObject[] all = GameObject.FindGameObjectsWithTag("Enemy");
        foreach (GameObject enemy in all)
        {
            if (enemy.GetComponent<NPC_Dialogue>().status != NPC_Status.PlayerWins)
                enemiesLeft.Add(enemy.transform.position);
        }

        // Destroy if no enemies left
        if (enemiesLeft.Count == 0)
            Destroy(gameObject);
    }

    void Update()
    {
        // Point to the closest enemy in the list
        int id = 0;
        for (int i=1; i<enemiesLeft.Count; i++)
        {
            if (Vector3.Distance(player.position, enemiesLeft[i]) < Vector3.Distance(player.position, enemiesLeft[id]))
                id = i;
        }
        Vector3 dir = enemiesLeft[id] - player.position;

        // Set position
        Vector2 pos = new Vector2(dir.x, dir.z).normalized * 1.8f * new Vector2(canvas.rect.height / 2f, canvas.rect.height / 2f);
        float ceiling = Mathf.Abs(pos.y) / (0.75f * canvas.rect.height / 2f);
        if (ceiling > 1)
            pos /= ceiling;
        float walls = Mathf.Abs(pos.x) / (0.85f * canvas.rect.width / 2f);
        if (walls > 1)
            pos /= walls;
        pointerPos.anchoredPosition = pos;
        // Set rotation
        pointerRot.rotation = Quaternion.LookRotation(Vector3.forward, new Vector3(dir.x, dir.z, 0));
    }
}
