using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.Audio;
using TMPro;

public class MenuManager : MonoBehaviour
{
    public GameObject PantallaDeCarga;
    public Slider slider;

    public AudioMixer audioMixer;

    public void SetVolume(float volume)
    {
        audioMixer.SetFloat("volume", volume);
    }

    public void SetQuality(int qualityIndex)
    {
        QualitySettings.SetQualityLevel(qualityIndex);
    }

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
