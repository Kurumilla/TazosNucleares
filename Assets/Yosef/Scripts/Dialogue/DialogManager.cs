using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public static class JsonHelper
{
    public static T[] FromJson<T>(string json)
    {
        Wrapper<T> wrapper = JsonUtility.FromJson<Wrapper<T>>(json);
        return wrapper.Items;
    }

    public static string ToJson<T>(T[] array)
    {
        Wrapper<T> wrapper = new Wrapper<T>();
        wrapper.Items = array;
        return JsonUtility.ToJson(wrapper);
    }

    public static string ToJson<T>(T[] array, bool prettyPrint)
    {
        Wrapper<T> wrapper = new Wrapper<T>();
        wrapper.Items = array;
        return JsonUtility.ToJson(wrapper, prettyPrint);
    }

    [Serializable]
    private class Wrapper<T>
    {
        public T[] Items;
    }
}

[Serializable]
public class Option
{
    public string answerText;
}

[Serializable]
public class Dialog
{
    public string isEvent;
    public string text;
    public string img;
    public Option[] options;
}

public class DialogManager : MonoBehaviour
{
    [Header("Object References")]
    public Write dialogBox;
    public Image characterImg;
    public TextMeshProUGUI characterName;
    public TextMeshProUGUI instructions;
    public Button[] choices;
    [Header("Data")]
    public TextAsset initialJson;

    int n = 0;
    private Dialog[] response;
    
    void Start()
    {
        StartNewDialogue(initialJson);
    }

    public void StartNewDialogue(TextAsset json)
    {
        // Leer el archivo
        try
        {
            response = JsonHelper.FromJson<Dialog>(json.text);
        }
        // Detecta error
        catch (Exception e) { Debug.LogError("No se pudo leer el archivo: " + e); }
        // Escribir el primer dialogo
        DialogEvent();
    }

    public void NextDialog()
    {
        n++;
        DialogEvent();
    }

    public void PrevDialog()
    {
        n--;
        DialogEvent();
    }

    void DialogEvent()
    {
        switch (response[n].isEvent)
        {
            case "CambioDePersonaje":   //Cambiar la imagen
                characterImg.sprite = Resources.Load<Sprite>("Prints/" + response[n].img);
                characterName.text = response[n].text;
                NextDialog();
                break;
            case "MostrarOpciones": //Desplegar los botones de opciones con el texto indicado
                dialogBox.gameObject.SetActive(false);
                for (int i=0; i<response[n].options.Length; i++)
                {
                    choices[i].gameObject.SetActive(true);
                    choices[i].GetComponentInChildren<Text>().text = response[n].options[i].answerText;
                }
                break;
            default:                //Di�logo simple
                dialogBox.NewOutput(response[n].text);
                break;
        }
    }

    public void ChooseAnswer(int x)
    {
        //Responder a la respuesta
        foreach (Button choice in choices)
            choice.gameObject.SetActive(false);
        NextDialog();
    }
}
