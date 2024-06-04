using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

//Para lo de Yosef
public enum NPC_Status
{
    Default,        //Aun no has interactuado con este
    PlayerWins,     //"Me ganaste jaja"
    PlayerLose      //"¿Quieres intentar otra vez?"
}

public class EstadoDeJuego : MonoBehaviour
{
    [Header("Para lo de Kurumilla:")]
    public Vector3 mapPosition;
    [Header("Para Miguel y Omar:")]
    public int personaje;
    [Header("Para lo de Yosef:")]
    public NPC_Status[] npc;
    public bool debugWins, debugLose;

    void Awake()
    {
        GameObject[] objs = GameObject.FindGameObjectsWithTag("Data");

        if (objs.Length > 1)
            Destroy(this.gameObject);

        DontDestroyOnLoad(this.gameObject);
    }

    void Update()
    {
        if (debugWins)
        {
            debugWins = false;
            npc[0] = NPC_Status.PlayerWins;
            SceneManager.LoadScene("GameWorld");
        }
        else if (debugLose)
        {
            debugLose = false;
            npc[0] = NPC_Status.PlayerLose;
            SceneManager.LoadScene("GameWorld");
        }
    }
}
