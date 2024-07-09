using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MapaManager : MonoBehaviour
{
    public GameObject panel;
    public RectTransform mapa, icon;

    [Header("NPC References")]
    public Transform[] npc;
    public RectTransform[] npcIcon;

    private void Start()
    {
        for (int i=0; i<npc.Length; i++)
        {
            float x = mapa.rect.x * npc[i].position.x / 50f;
            float y = mapa.rect.y * npc[i].position.z / 50f;
            npcIcon[i].anchoredPosition = new Vector2(-x, -y);
        }
    }

    void Update()
    {
        if (Input.GetButtonDown("Jump"))
        {
            panel.SetActive(true);
        }
        if (panel.active)
        {
            Vector3 pos = GameObject.FindWithTag("Player").transform.position;
            float x = mapa.rect.x * pos.x / 50f;
            float y = mapa.rect.y * pos.z / 50f;
            icon.anchoredPosition = new Vector2(-x, -y);
        }
    }

    public void CloseMap()
    {
        panel.SetActive(false);
    }
}