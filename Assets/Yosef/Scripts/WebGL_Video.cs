using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class WebGL_Video : MonoBehaviour
{
    public string filename;

    void Start()
    {
        PlayVideo();
    }

    public void PlayVideo()
    {
        VideoPlayer video = GetComponent<VideoPlayer>();
        if (video)
        {
            string path = System.IO.Path.Combine(Application.streamingAssetsPath, filename);
            Debug.Log(path);
            video.url = path;
            video.Play();
        }
    }
}
