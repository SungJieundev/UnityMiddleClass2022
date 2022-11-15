using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine.UI;

public class PhotonLobby : MonoBehaviourPunCallbacks
{
    public static PhotonLobby lobby;
    RoomInfo[] rooms;
    public GameObject btnJoin;
    public GameObject btnLeave;
    public Text txtInfo;
    public Text txtNumPlayers;

    private void Awake()
    {
        lobby = this;
    }
    private void Start()
    {
        PhotonNetwork.ConnectUsingSettings();
    }
    private void Update()
    {
        int numPlayers = PhotonNetwork.CountOfPlayers;
        txtNumPlayers.text = "Number of Player: "+ numPlayers.ToString()+ "/20";
    }

    public override void OnConnectedToMaster()
    {
        string message = "Connected to master";
        Debug.Log(message);
        txtInfo.text = message;
        PhotonNetwork.AutomaticallySyncScene = true;
        btnJoin.SetActive(true);
    }

    public void OnJoinButtonClicked(){
        Debug.Log("Join button click");
        btnJoin.SetActive(false);
        btnLeave.SetActive(true);
        PhotonNetwork.JoinRandomRoom();
    }

    public override void OnJoinRandomFailed(short returnCode, string message)
    {
        string mes = "Failed to join the room";
        Debug.Log(mes);
        txtInfo.text = mes;
        CreateRoom();
    }

    void CreateRoom(){
        string mes = "Trying to create a room";
        Debug.Log(mes);
        txtInfo.text = mes;
        int randomRoomName = Random.Range(0, 10000);
        RoomOptions roomOps = new RoomOptions(){IsVisible=true, IsOpen=true, MaxPlayers=20};
        PhotonNetwork.CreateRoom("Room" + randomRoomName,roomOps);
    }

    public void OnCancelButtonClick(){
        btnLeave.SetActive(false);
        btnJoin.SetActive(true);
        PhotonNetwork.LeaveRoom();
    }
}
