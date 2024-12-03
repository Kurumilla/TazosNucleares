using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TutorialesView : MonoBehaviour
{
    public GameObject panelGameObject;
    public List<string> listaDeTutoriales = new List<string>();
    public TMP_Text textoTip;
    public BoxCollider boxCollider;
    public EstadoDeJuego estadoDeJuego;

    public bool activarIniciando = false;

    int index = 0;
    bool chocando = false;

    bool unUso = true;

    private void Start()
    {
        estadoDeJuego = GameObject.Find("Estado de Juego").GetComponent<EstadoDeJuego>();

        if (listaDeTutoriales.Count <= 1)
        {
            Debug.LogWarning("No se ha agregado ningun texto para el tutorial");
        }
        else
        {
            textoTip.text = listaDeTutoriales[0];
            if (!activarIniciando)
            {
                panelGameObject.SetActive(false);
            }
        }
    }

    void Update()
    {
        if (estadoDeJuego.textoImportante && unUso && chocando)
        {
            panelGameObject.SetActive(false);
            unUso = !unUso;
        }
        else if (!estadoDeJuego.textoImportante && !unUso && chocando)
        {
            Debug.Log("Hola");
            panelGameObject.SetActive(true);
            unUso = true;
        }
        if (Input.GetKeyDown(KeyCode.E) && (chocando || activarIniciando) && index <= listaDeTutoriales.Count && !estadoDeJuego.textoImportante)
        {
            if (index >= listaDeTutoriales.Count-1)
            {
                panelGameObject.SetActive(false);
                estadoDeJuego.movimientoBloqueado = false;
                Destroy(gameObject);
            }
            else
            {
                index++;
                textoTip.text = listaDeTutoriales[index];
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Enter");
        estadoDeJuego.movimientoBloqueado = true;
        chocando = true;
        panelGameObject.SetActive(true);
    }
    private void OnTriggerExit(Collider other)
    {
        chocando = false;
        panelGameObject.SetActive(false);
    }
}
