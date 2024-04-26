using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuManager : MonoBehaviour
{
    public GameObject PantallaDeCarga;
    public Slider slider;

    public void Play_Button(int NumeroEscena)
    {
        StartCoroutine(CargarAsync(NumeroEscena));
    }

    IEnumerator CargarAsync(int NumeroEscena)
    {
        AsyncOperation Operacion = SceneManager.LoadSceneAsync(NumeroEscena);

        PantallaDeCarga.SetActive(true);

        while(!Operacion.isDone)
        {
            float Progreso = Mathf.Clamp01(Operacion.progress / .9f);
            slider.value = Progreso;

            yield return null;
        }
    }

    public void Exit_Button()
    {
        Debug.Log("Saliendo del juego...");
        Application.Quit();
    }
}
