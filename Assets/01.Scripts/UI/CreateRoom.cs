using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;

public class CreateRoom : MonoBehaviourPunCallbacks
{
    [SerializeField] private Text roomName;
    public RoomCanvases _roomCanvases;

    private void Start() {
        
        PhotonNetwork.ConnectUsingSettings();
    }

    public void CanvasInitialize(RoomCanvases roomCanvases){

        _roomCanvases = roomCanvases;
    }

    public override void OnConnectedToMaster() {
        
        PhotonNetwork.JoinLobby();
        
    }

    public override void OnCreatedRoom(){

        base.OnCreatedRoom();
        Debug.Log($"OnCreatedRoom : {this}");
        _roomCanvases.currentRoomCanvas.Show();
    }

    public override void OnCreateRoomFailed(short returnCode, string message)
    {
        base.OnCreateRoomFailed(returnCode, message);
        Debug.Log($"OnCreatedRoomFailed :{this}");
    }



    public void OnClickCreateRoom(){

        if(!PhotonNetwork.IsConnected){

            return;
        }
    }
}
