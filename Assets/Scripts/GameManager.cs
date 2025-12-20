using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    // Creamos la variable para poder instanciar nuestro manager
    public static GameManager instance;

    public Vector3 playerPosition; //Guardamos la posición en el mundo del jugador

    void Awake()
    {
        // Nos aseguramos de que el objeto se mantenga permanentemente o
        // si hay más de uno este se autoelemine para evitar conflictos.
        if (instance == null) 
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    // En los metodos de SaveState y LoadState podemos agregarle más adelante lo que necesitemos
    // enves de solo la posición en el mundo. -------------------------------------------------------

    // Estos metodos se tienen que llamar en los otros scripts en donde se necesite que se cargue
    // por ejemplo:

    // - Para guardar la posicion de un cambio de escena:
    //   GameManager.instance.SaveState(player.transform.position);
    // 
    //   Donde tenemos que la parte de [ player ] es el gameobject que es nuestro jugador.

    // - Para cargar la posicion al cambiar de escena nuevamente:
    //   GameManager.instance.LoadState(player);
    //
    //   Nuevamente aquí tenemos que el [ player ] es el gameobject de nuestro jugador.

    // Método para guardar la posición del personaje en el mundo
    public void SaveState(Vector3 position)
    {
        playerPosition = position;
    }

    // Método para cargar el estado
    public void LoadState(GameObject player)
    {
        player.transform.position = playerPosition;
        // Aquí podemos agregar más lineas para cargar lo que se necesite
    }

    //-----------------------------------------------------------------------------------------------
}
