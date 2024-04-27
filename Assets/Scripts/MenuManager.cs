using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.Audio;
using TMPro;

public class MenuManager : MonoBehaviour
{
    //Control del volumen
    public AudioMixer audioMixer;

    public void SetVolume(float volume)
    {
        audioMixer.SetFloat("volume", volume);
    }

    //Funcion de Calidad de graficos
    public void SetQuality(int qualityIndex)
    {
        QualitySettings.SetQualityLevel(qualityIndex);
    }

    //Sistema del menu principal, inicio, pantalla de carga y salida del juego
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

    //Sistema de pausa
    [SerializeField] public GameObject menuPausa;
    private bool pausa = false;

    public void Pause()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (pausa == false)
            {
                menuPausa.SetActive(true);
                pausa = true;

                Time.timeScale = 0f;
                Cursor.visible = true;
                Cursor.lockState = CursorLockMode.None;

                AudioSource[] sounds = FindObjectsOfType<AudioSource>();

                for (int i = 0; i < sounds.Length; i++)
                {
                    sounds[i].Pause();
                }
            }
            else if (pausa == true)
            {
                Resume();
            }
        }
    }

    public void Resume()
    {
        menuPausa.SetActive(false);
        pausa = false;

        Time.timeScale = 1f;
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;

        AudioSource[] sounds = FindObjectsOfType<AudioSource>();

        for (int i = 0; i < sounds.Length; i++)
        {
            sounds[i].Play();
        }
    }

    public void ReturnMenu(string menuName)
    {
        SceneManager.LoadScene(menuName);
    }
}
