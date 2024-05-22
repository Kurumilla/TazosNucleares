using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{
    public GameObject mainWindow, loadingWindow, optionWindow, creditsWindow, quitWindow;

    void Start()
    {
        mainWindow.SetActive(true);
        loadingWindow.SetActive(false);
        optionWindow.SetActive(false);
        quitWindow.SetActive(false);
    }

    public void _newGame()
    {
        SceneManager.LoadScene(1);
    }

    public void _loadingGame(int index)
    {
        switch (index)
        {
            default:
                SceneManager.LoadScene(1);
                break;
        }
    }

    public void _loadingWindowActive()
    {
        mainWindow.SetActive(!mainWindow.activeSelf);
        loadingWindow.SetActive(!loadingWindow.activeSelf);
    }
    public void _optionWindowActive()
    {
        mainWindow.SetActive(!mainWindow.activeSelf);
        optionWindow.SetActive(!optionWindow.activeSelf);
    }

    public void _creditsWindowActive()
    {
        mainWindow.SetActive(!mainWindow.activeSelf);
        creditsWindow.SetActive(!creditsWindow.activeSelf);
    }

    public void _quitWindowActive()
    {
        mainWindow.SetActive(!mainWindow.activeSelf);
        quitWindow.SetActive(!quitWindow.activeSelf);
    }
}
