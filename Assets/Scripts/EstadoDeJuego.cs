using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

//Para lo de Yosef
public enum NPC_Status
{
    Default,        //Aun no has interactuado con este
    PlayerWins,     //"Me ganaste jaja"
    PlayerLose      //"�Quieres intentar otra vez?"
}

public class EstadoDeJuego : MonoBehaviour
{
    [Header("Para lo de Kurumilla:")]
    public Vector3 playerPos;
    public bool textoImportante = false;
    public bool movimientoBloqueado = false;
    [Header("Para Miguel y Omar:")]
    public int personaje;
    [Header("Para lo de Yosef:")]
    public NPC_Status[] npc;

    void Awake()
    {
        GameObject[] objs = GameObject.FindGameObjectsWithTag("Data");

        if (objs.Length > 1)
            Destroy(this.gameObject);

        DontDestroyOnLoad(this.gameObject);
    }

    public void GameOver(bool _playerWins)
    {
        npc[personaje] = _playerWins ? NPC_Status.PlayerWins : NPC_Status.PlayerLose;
        if (_playerWins)
            SceneManager.LoadScene("GameOverWin");
        else
            SceneManager.LoadScene("GameOverLose");
    }
}
