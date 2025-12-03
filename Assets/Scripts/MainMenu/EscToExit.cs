using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EscToExit : MonoBehaviour
{
    public bool salirDelJuego = false;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            gameObject.SetActive(!gameObject.activeSelf);
        }
        if (Input.GetKeyDown(KeyCode.Return) && salirDelJuego)
        {
            gameObject.SetActive(!gameObject.activeSelf);
        }
    }
}
