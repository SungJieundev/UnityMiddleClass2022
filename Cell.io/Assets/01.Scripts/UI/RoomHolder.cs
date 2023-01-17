using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Realtime;
using Photon.Pun;

public class RoomHolder : MonoBehaviour
{
    [SerializeField] private Text _text;
    public RoomInfo _roomInfo;
    public RoomCanvases _roomCanvases;

    public void FirstInitialize(RoomCanvases roomCanvases){

        _roomCanvases = roomCanvases;
    }
    public void SetRoomInfo(RoomInfo roomInfo){
        _roomInfo = roomInfo;
        _text.text = $"Max: {roomInfo.MaxPlayers}, {roomInfo}";
    }

    // 원하는 방을 클릭해서 접속
    public void OnClickJoinRoomButton(){
        PhotonNetwork.LocalPlayer.NickName = _roomCanvases.nicknameInput.text;
        PhotonNetwork.JoinRoom(_roomInfo.Name);
    }
}
