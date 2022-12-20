using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateJoinRoomCanvas : MonoBehaviour
{

    [SerializeField] private CreateRoom _createRoom;
    private RoomCanvases _roomCanvases;

    public void CanvasInitialize(RoomCanvases roomCanvases){
        
        _roomCanvases = roomCanvases;
        _createRoom.CanvasInitialize(roomCanvases);
    }
}
