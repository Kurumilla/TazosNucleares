using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class ClickSound : MonoBehaviour
{
    public AudioSource audioButtonUI;

    public void _buttonAudio()
    {
        audioButtonUI.Play();
    }
}
