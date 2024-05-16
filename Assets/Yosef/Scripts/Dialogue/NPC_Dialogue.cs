using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC_Dialogue : MonoBehaviour
{
    public TextAsset dialogueJson;
    public DialogManager manager;
    private bool alreadyTalked = false;

    void Update()
    {
        if(!alreadyTalked)
        {
            RaycastHit hit;
            if (Physics.Raycast(transform.position, transform.forward, out hit, Mathf.Infinity))
            {
                if (hit.collider.gameObject.CompareTag("Player"))
                {
                    alreadyTalked = true;
                    manager.StartNewDialogue(dialogueJson);
                }
            }
        }
    }
}
