using Photon.Pun;
using Photon.Realtime;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NetworkManager : MonoBehaviourPunCallbacks
{
    [SerializeField]
    GameObject playerPrefab;
    [SerializeField]
    Vector3 spawnPosition;
    
    void Start()
    {
        PhotonNetwork.Instantiate(playerPrefab.name, spawnPosition, Quaternion.identity);
    }

    void Update()
    {
        
    }
    public void Leave() 
    {
        PhotonNetwork.LeaveRoom();
    }

    /// <summary>
    /// ѕроисходит когда текущий игрок покидает комнату
    /// </summary>
    public override void OnLeftRoom()
    {
        SceneManager.LoadScene(0);
    }

    public override void OnPlayerEnteredRoom(Player newPlayer)
    {
        Debug.LogFormat("Plauer {0} entered room", newPlayer.NickName);
    }

    public override void OnPlayerLeftRoom(Player otherPlayer)
    {
        Debug.LogFormat("Plauer {0} left room", otherPlayer.NickName);
    }
}
