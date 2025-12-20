// Hecho por Leonardo

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;
using UnityEngine.SceneManagement;

public class HideVideo : MonoBehaviour
{
    [SerializeField]
    VideoPlayer myVideoPlayer;

    // Start is called before the first frame update
    void Start()
    {
        myVideoPlayer.loopPointReached += DoSomething;
    }

    void DoSomething(VideoPlayer vp)
    {
        SceneManager.LoadScene("MainMenu");
    }
}