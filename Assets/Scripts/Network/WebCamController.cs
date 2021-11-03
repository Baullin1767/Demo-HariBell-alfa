using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WebCamController : _InteractiveObject
{
   
    protected override void Start()
    {
        WebCamTexture webCamTexture = new WebCamTexture();
        Renderer renderer = GetComponent<Renderer>();
        renderer.material.mainTexture = webCamTexture;
        webCamTexture.Play();
    }
}
