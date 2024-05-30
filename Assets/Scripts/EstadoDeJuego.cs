using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Para lo de Yosef
public enum NPC_Status
{
    Default,    //Aun no has interactuado con este
    Victoria,   //Player wins: "Me ganaste jaja"
    Derrota     //Player lose: "¿Quieres intentar otra vez?"
}

public class JsonLector : MonoBehaviour
{
    public Vector3 mapPosition;     //Para lo de Kurumilla
    public int personaje;           //Para lo de Miguel y Omar

    public NPC_Status npc1;
    public NPC_Status npc2;
    public NPC_Status npc3;
    // etc

    void Awake()
    {
        GameObject[] objs = GameObject.FindGameObjectsWithTag("Data");

        if (objs.Length > 1)
            Destroy(this.gameObject);

        DontDestroyOnLoad(this.gameObject);
    }
}
