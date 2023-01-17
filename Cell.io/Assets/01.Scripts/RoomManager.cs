using Photon.Pun;
using Photon.Realtime;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RoomManager : MonoBehaviourPunCallbacks
{
    public string roomName = "MyRoom";
    public InputField nicknameInput;
 
    private void Start(){

        Debug.Log("Connecting...");
    }

    private void Update(){

        if (Input.GetKeyDown(KeyCode.Space)){

            PhotonNetwork.ConnectUsingSettings();
        }
    }

    public override void OnConnectedToMaster(){

        base.OnConnectedToMaster();

        PhotonNetwork.NickName = nicknameInput.text;
        nicknameInput.gameObject.SetActive(false);

        Debug.Log("Connected To Master");
        PhotonNetwork.JoinLobby();
    }

    public override void OnJoinedLobby(){

        base.OnJoinedLobby();

        Debug.Log("Joined Lobby");
        PhotonNetwork.JoinOrCreateRoom(roomName, null, null);
    }

    public override void OnJoinedRoom(){

        base.OnJoinedRoom();
        
        Debug.Log("Joined Room");
        
        GameManager.instance.SpawnPlayer();
        GameManager.instance.SpawnVirus();
    }
}
