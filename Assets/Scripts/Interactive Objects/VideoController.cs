using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VideoController : MonoBehaviour
{
    UnityEngine.Video.VideoPlayer videoPlayer;
    private void Start()
    {
        videoPlayer = GetComponent<UnityEngine.Video.VideoPlayer>();
    }

    public void Play() 
    {
        videoPlayer.Play();
    }
}
