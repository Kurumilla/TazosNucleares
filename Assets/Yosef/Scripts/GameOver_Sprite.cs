using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameOver_Sprite : MonoBehaviour
{
    public bool _playerWins;

    void Start()
    {
        Sprite[] spritesheet = Resources.LoadAll<Sprite>("Prints/npc_humano_sprites");
        EstadoDeJuego status = GameObject.Find("Estado de Juego").GetComponent<EstadoDeJuego>();
        int id = _playerWins ? 2 : 1;
        id += status.personaje * 3;
        GetComponent<Image>().sprite = spritesheet[id];
    }
}
