using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MapaManager : MonoBehaviour
{
    public GameObject panel;
    public RectTransform mapa, playerIcon;

    [Header("NPC References")]
    public Transform[] npc;
    public RectTransform[] npcIcon;

    private void Start()
    {
        // Automatic placement of NPC icons on the map, according to their world position
        for (int i=0; i<npc.Length; i++)
        {
            float x = mapa.rect.x * npc[i].position.x / 57.5f;
            float y = mapa.rect.y * npc[i].position.z / 57.5f;
            npcIcon[i].anchoredPosition = new Vector2(-x, -y);
        }
    }

    void Update()
    {
        // Toggle Map with keyboard
        if (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.M))
        {
            panel.SetActive(!panel.activeSelf);
        }
        // Update player position on the map
        if (panel.activeSelf)
        {
            Vector3 pos = GameObject.FindWithTag("Player").transform.position;
            float x = mapa.rect.x * pos.x / 57.5f;
            float y = mapa.rect.y * pos.z / 57.5f;
            playerIcon.anchoredPosition = new Vector2(-x, -y);
        }
    }

    // Toggle Map with UI buttons
    public void OpenMap() { panel.SetActive(true); }
    public void CloseMap() { panel.SetActive(false); }
}
