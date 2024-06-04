using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC_Dialogue : MonoBehaviour
{
    public DialogManager manager;
    [Header("Text Assets")]
    public TextAsset dialogueDefault;
    public TextAsset dialoguePlayerWins;
    public TextAsset dialoguePlayerLose;
    [Header("NPC Variables")]
    public bool active = true;
    public int id = 0;
    public NPC_Status status;
    public float range;

    private void Start()
    {
        status = GameObject.Find("Estado de Juego").GetComponent<EstadoDeJuego>().npc[id];
    }

    private void Update()
    {
        if (active)
        {
            RaycastHit hit;
            if (Physics.Raycast(transform.position, transform.forward, out hit, range + 0.5f))
            {
                if (hit.collider.gameObject.CompareTag("Player"))
                {
                    active = false;
                    manager.currentNPC = this;
                    switch (status)
                    {
                        case NPC_Status.Default:
                            Debug.Log("Default");
                            manager.StartNewDialogue(dialogueDefault);
                            break;
                        case NPC_Status.PlayerWins:
                            Debug.Log("Win");
                            manager.StartNewDialogue(dialoguePlayerWins);
                            break;
                        case NPC_Status.PlayerLose:
                            Debug.Log("Lose");
                            manager.StartNewDialogue(dialoguePlayerLose);
                            break;
                    }
                }
            }
        }
    }
}
