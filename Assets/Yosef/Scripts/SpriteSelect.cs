using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameOver_Sprite : MonoBehaviour
{
    [Header("0=Default, 1=Happy, 2=Sad")]
    public int spriteOffset;

    void Start()
    {
        Sprite[] spritesheet = Resources.LoadAll<Sprite>("Prints/npc_humano_sprites");
        EstadoDeJuego status = GameObject.Find("Estado de Juego").GetComponent<EstadoDeJuego>();
        int id = status.personaje * 3 + spriteOffset;
        GetComponent<Image>().sprite = spritesheet[id];
    }
}
