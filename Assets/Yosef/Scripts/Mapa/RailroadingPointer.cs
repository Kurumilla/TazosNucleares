using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RailroadingPointer : MonoBehaviour
{
    public float distanceToHide = 10f;

    [Header("Object References")]
    private Transform player;
    public List<Transform> enemies = new List<Transform>();
    public List<Sprite> sprites = new List<Sprite>();

    [Header("UI References")]
    public RectTransform pointerPos;
    public RectTransform pointerRot;
    private RectTransform canvas;
    public Image img;
    private CanvasGroup visible;

    void Start()
    {
        // Resize
        canvas = FindObjectOfType<Canvas>().GetComponent<RectTransform>();
        visible = GetComponent<CanvasGroup>();
        pointerPos.sizeDelta = new Vector2(canvas.rect.height / 4f, canvas.rect.height / 4f);

        // Add to the list the enemies you havent beat yet
        player = GameObject.FindWithTag("Player").transform;
        for (int i=enemies.Count-1; i>=0; i--)
        {
            if (enemies[i].gameObject.GetComponent<NPC_Dialogue>().status == NPC_Status.PlayerWins)
            {
                enemies.RemoveAt(i);
                sprites.RemoveAt(i);
            }
        }

        // Destroy if no enemies left
        if (enemies.Count == 0)
            Destroy(gameObject);
    }

    void Update()
    {
        // Point to the closest enemy in the list
        int id = 0;
        for (int i=1; i<enemies.Count; i++)
        {
            if (Vector3.Distance(player.position, enemies[i].position) < Vector3.Distance(player.position, enemies[id].position))
                id = i;
        }
        // Hide if close enough to see the enemy
        if (Vector3.Distance(player.position, enemies[id].position) < distanceToHide)
            visible.alpha = 0;
        else
            visible.alpha = 1;

        // Get position and image to use
        Vector3 dir = enemies[id].position - player.position;
        img.sprite = sprites[id];
        // Calculate canvas position
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
