using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ResolucionesYPantalla : MonoBehaviour
{
    public TMP_Dropdown resolutionDD;
    public Toggle fullScreenToggle;

    Resolution[] AllResolutions;
    bool isFullScreen;
    int selectResolution;
    List<Resolution> selectResolutionList = new List<Resolution>();

    void Start()
    {
        isFullScreen = true;
        AllResolutions = Screen.resolutions;

        List<string> resolutionStringList = new List<string>();
        string newRes;
        foreach(Resolution res in AllResolutions)
        {
            newRes = res.width.ToString() + " x " + res.height.ToString();

            if (!resolutionStringList.Contains(newRes)){

                resolutionStringList.Add(newRes);
                selectResolutionList.Add(res);
            }  
        }

        resolutionDD.AddOptions(resolutionStringList);
    }

    public void _ChangeResolution()
    {
        selectResolution = resolutionDD.value;
        Screen.SetResolution(selectResolutionList[selectResolution].width, selectResolutionList[selectResolution].height, isFullScreen);
    }


    public void _ChangeFullScreen()
    {
        isFullScreen = fullScreenToggle.isOn;
        Screen.SetResolution(selectResolutionList[selectResolution].width, selectResolutionList[selectResolution].height, isFullScreen);
    }

    void Update()
    {
        
    }
}
