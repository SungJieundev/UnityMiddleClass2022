using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//canvas 관리용 클래스
public class RoomCanvases : MonoBehaviour 
{
    public CurrentRoomCanvas currentRoomCanvas;
    [SerializeField] private CreateJoinRoomCanvas createJoinRoomCanvas;

    private void Awake() {
        
        CanvasInitialize();
    }

    private void CanvasInitialize(){

        currentRoomCanvas.CanvasInitialize(this);
        createJoinRoomCanvas.CanvasInitialize(this);
    }
}
