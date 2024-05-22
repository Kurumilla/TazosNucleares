using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OptionsMenuController : MonoBehaviour
{
    public GameObject[] apartadosOpciones;

    void Start()
    {
        _ShowWindow(0);
    }

    public void _ShowWindow(int index)
    {
        // Desactivar todas las ventanas
        for (int i = 0; i < apartadosOpciones.Length; i++)
        {
            apartadosOpciones[i].SetActive(false);
        }

        // Activar la ventana correspondiente
        if (index >= 0 && index < apartadosOpciones.Length)
        {
            apartadosOpciones[index].SetActive(true);
        }
    }
}
