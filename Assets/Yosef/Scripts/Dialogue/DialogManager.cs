using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

[Serializable]
public class Option
{
    public string isEffect;
    public string choiceText;
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
    [Header("UI References")]
    public Write dialogBox;
    public Image characterImg;
    public TextMeshProUGUI characterName;
    public TextMeshProUGUI instructions;
    public Button[] choices;

    [Header("Object References")]
    public BasicMovement player;
    public NPC_Dialogue currentNPC;

    [Header("Data")]
    public TextAsset initialJson;
    private EstadoDeJuego gameState;
    //Variables privadas para leer el json
    int n = 0;
    private bool active;
    private Dialog[] response;
    
    void Start()
    {
        gameState = GameObject.Find("Estado de Juego").GetComponent<EstadoDeJuego>();
        // La narración se activa si es tu primera vez aqui
        if (gameState.playerPos == Vector3.zero)
            StartNewDialogue(initialJson);
        else
            player.gameObject.transform.position = gameState.playerPos;
    }

    void Update()
    {
        //E key to continue
        if (active && Input.GetKeyDown(KeyCode.E))
            NextDialog();
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
        n = 0;
        active = true;
        dialogBox.gameObject.SetActive(true);
        player.activado = false;
        DialogEvent();
    }

    public void NextDialog()
    {
        n++;
        if (n < response.Length)
        {
            DialogEvent();
        }
        else
        {
            //Cambiar setup de Dialogo ? Movimiento
            active = false;
            player.activado = true;
            dialogBox.gameObject.SetActive(false);
            //Reactivar al NPC con delay
            StartCoroutine(ReactivateNPC());
        }
    }

    IEnumerator ReactivateNPC()
    {
        yield return new WaitForSeconds(1.0f);
        currentNPC.active = true;
    }

    void DialogEvent()
    {
        switch (response[n].isEvent)
        {
            case "CambiarPersonaje":    //Cambiar la imagen
                characterImg.sprite = Resources.Load<Sprite>("Prints/" + response[n].img);
                characterName.text = response[n].text;
                NextDialog();
                break;
            case "MostrarOpciones":     //Desplegar los botones de opciones con el texto indicado
                active = false;
                dialogBox.gameObject.SetActive(false);
                for (int i=0; i<response[n].options.Length; i++)
                {
                    choices[i].gameObject.SetActive(true);
                    choices[i].GetComponentInChildren<TextMeshProUGUI>().text = response[n].options[i].choiceText;
                }
                break;
            default:                    //Diálogo simple
                dialogBox.NewOutput(response[n].text);
                break;
        }
    }

    public void ChooseAnswer(int x)
    {
        //Apagar opciones
        foreach (Button choice in choices)
            choice.gameObject.SetActive(false);
        //Mostrar respuesta
        active = true;
        dialogBox.gameObject.SetActive(true);
        dialogBox.NewOutput(response[n].options[x].answerText);
        //Realizar efecto
        switch (response[n].options[x].isEffect)
        {
            case "Play":
                gameState.personaje = currentNPC.id;
                gameState.playerPos = player.gameObject.transform.position;
                SceneManager.LoadScene("GameTest");
                break;
        }
    }
}
