using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_Shrink : MonoBehaviour
{
    public float speed = 1f;
    public float delay = 1f;
    private float maxDelay;
    private float progress = 0;
    RectTransform rect;

    [Header("Initial Anchors")]
    public Vector2 minAnchors1;
    public Vector2 maxAnchors1;

    [Header("Target Anchors")]
    public Vector2 minAnchors2;
    public Vector2 maxAnchors2;

    void Awake()
    {
        maxDelay = delay;
        rect = GetComponent<RectTransform>();
    }

    // Update the scoreboard and make it real big
    public void ShowScores()
    {
        delay = maxDelay;
        progress = 0;
        rect.anchorMin = minAnchors1;
        rect.anchorMax = maxAnchors1;
        rect.sizeDelta = Vector2.zero;
    }

    // Shrink to normal size over time
    void Update()
    {
        if (delay > 0)
        {
            delay -= Time.deltaTime;
        }
        else if (progress < 1)
        {
            progress += speed * Time.deltaTime;
            progress = Mathf.Clamp(progress, 0, 1f);

            rect.anchorMin = Vector2.Lerp(minAnchors1, minAnchors2, progress);
            rect.anchorMax = Vector2.Lerp(maxAnchors1, maxAnchors2, progress);
            rect.sizeDelta = Vector2.zero;
        }
    }
}
