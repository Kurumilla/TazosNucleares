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
        EstadoDeJuego status = GameObject.Find("Estado de Juego").GetComponent<EstadoDeJuego>();
        if (status.personaje == 5) //Jefe
        {
            transform.localScale /= 2;
            GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Prints/Jefe");
        }
        else
        {
            Sprite[] spritesheet = Resources.LoadAll<Sprite>("Prints/npc_humano_sprites");
            int id = status.personaje * 3 + spriteOffset;
            GetComponent<SpriteRenderer>().sprite = spritesheet[id];
        }
    }
}
