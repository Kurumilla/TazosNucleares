using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class RoundOver : MonoBehaviour
{
    [Header("Settings")]
    public bool active = true;
    public float countdown;
    private float maxCount;
    public int heads, tails;

    [Header("Object References")]
    GameObject canvas;
    public TMP_Text txtHeadsCounter, txtTailsCounter;

    void Start()
    {
        canvas = GameObject.Find("Canvas");
        maxCount = countdown;
    }

    void Update()
    {
        if (active && countdown<=0)
        {
            // Setup
            AimingPhase();
            heads = 0;
            tails = 0;
            // Count
            GameObject[] board = GameObject.FindGameObjectsWithTag("Tazo");
            foreach (GameObject item in board)
            {
                if (Vector3.Angle(item.transform.up, Vector3.up) < 90f)
                    heads++;
                else
                    tails++;
            }
            // Display
            txtHeadsCounter.text = "HEADS: " + heads.ToString();
            txtTailsCounter.text = "TAILS: " + tails.ToString();
        }
        else if (active)
        {
            countdown -= Time.deltaTime;
        }
    }

    public void BouncingPhase()
    {
        countdown = maxCount;
        active = true;
        canvas.SetActive(false);
    }

    public void AimingPhase()
    {
        active = false;
        canvas.SetActive(true);
    }
}
