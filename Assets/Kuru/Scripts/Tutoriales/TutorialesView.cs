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

    int index = 0;
    bool chocando = false;

    private void Start()
    {
        if(listaDeTutoriales.Count <= 1)
        {
            Debug.LogWarning("No se ha agregado ningun texto para el tutorial");
        }
        else
        {
            textoTip.text = listaDeTutoriales[0];
            panelGameObject.SetActive(false);
        }
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && chocando && index <= listaDeTutoriales.Count)
        {
            if (index >= listaDeTutoriales.Count-1)
            {
                panelGameObject.SetActive(false);
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
        Debug.Log("Hola");
        chocando = true;
        panelGameObject.SetActive(true);
    }
    private void OnTriggerExit(Collider other)
    {
        Debug.Log("Hola");
        chocando = false;
        panelGameObject.SetActive(false);
    }
}
