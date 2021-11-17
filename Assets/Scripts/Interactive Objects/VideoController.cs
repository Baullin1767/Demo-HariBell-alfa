using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VideoController : _InteractiveObject
{
    UnityEngine.Video.VideoPlayer videoPlayer;
    protected override void Start()
    {
        videoPlayer = GetComponent<UnityEngine.Video.VideoPlayer>();
    }

    void Play() 
    {
        videoPlayer.Play();
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            videoPlayer.Play(); 
        }
    }

    void OnTriggerExit(Collider other) 
    {
        if (other.gameObject.CompareTag("Player"))
        {
            videoPlayer.Pause(); 
        }
    }
}
