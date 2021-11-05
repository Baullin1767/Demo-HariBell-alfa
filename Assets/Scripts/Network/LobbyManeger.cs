using UnityEngine;
using Photon.Pun;
using UnityEngine.UI;

public class LobbyManeger : MonoBehaviourPunCallbacks
{
    public InputField login;
    void Start()
    {
        PhotonNetwork.NickName = login.text;

        PhotonNetwork.AutomaticallySyncScene = true;
        PhotonNetwork.GameVersion = "1";
        PhotonNetwork.ConnectUsingSettings();
    }

    public override void OnConnectedToMaster()
    {
        Debug.Log("Connected to Master");
    }

    public void CraeteRoom() 
    {
        PhotonNetwork.CreateRoom(null, new Photon.Realtime.RoomOptions { MaxPlayers = 2 });
    }

    public void JoinRoom() 
    {
        PhotonNetwork.JoinRandomRoom();
    }

    public override void OnJoinedRoom()
    {
        Debug.Log("Joined the room");

        PhotonNetwork.LoadLevel("General Hall");
    }

    public void Exit() 
    {
        Application.Quit();
    }
}
