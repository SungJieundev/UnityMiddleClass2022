using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;
using Photon.Realtime;

public class PhotonRoom : MonoBehaviourPunCallbacks
{
    public static PhotonRoom room;
    public int currentScene;
    public int multiPlayScene;

    public Text txtInfo;
    int numConnected;
    private void Awake() {
        if(PhotonRoom.room == null){
            PhotonRoom.room = this;
        }
        else{
            if(PhotonRoom.room!=this){
                Destroy(PhotonRoom.room.gameObject);
                PhotonRoom.room = this;
            }
        }

        DontDestroyOnLoad(this.gameObject);
    }

    void StartGame(){
        string msgMatchFound = "Match found, starting a game (vs)";
        txtInfo.text = msgMatchFound;
        Debug.Log(msgMatchFound);
        PhotonNetwork.LoadLevel(multiPlayScene);
    }

    public override void OnJoinedRoom()
    {
        base.OnJoinedRoom();
        Debug.Log("We are in a room");
        numConnected = PhotonNetwork.PlayerList.Length;
        string msgJoinRoom = "Connected Room Name: " + PhotonNetwork.CurrentRoom.Name + " Number of Players connected: " + numConnected;
        Debug.Log(msgJoinRoom);
        txtInfo.text = string.Format(msgJoinRoom, PhotonNetwork.CurrentRoom.Name, numConnected);
        base.OnJoinedRoom();
        Debug.Log(string.Format(msgJoinRoom, PhotonNetwork.CurrentRoom.Name, numConnected));

        StartGame();
    }
    

    
}
