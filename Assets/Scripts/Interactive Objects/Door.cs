using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Door : _InteractiveObject
{
    [SerializeField] string sceneName;
    public override void Interective()
    {
        Debug.Log("Door is opened, you are leave the room");
        SceneManager.LoadScene(sceneName);
    }
}
