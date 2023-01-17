using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class RoomListMenu : MonoBehaviourPunCallbacks
{
    [SerializeField] private Transform _content;

    [SerializeField] private RoomHolder _roomHolder;

    private List<RoomHolder> _listings = new List<RoomHolder>();
    RoomCanvases _roomCanvases;

    public void FirstInitialize(RoomCanvases canvases){

        _roomCanvases = canvases;
    }

    public override void OnJoinedRoom()
    {
        _roomCanvases.currentRoomCanvas.Show();
        //_content destroy
        DestroyChildren(_content); //roomList 초기화
        _listings.Clear();
    }
    public override void OnRoomListUpdate(List<RoomInfo> roomList){

        Debug.Log($"Room List {roomList.Count}");

        foreach(RoomInfo info in roomList){

            if(info.RemovedFromList){ // deleteRoom -> removedFromList = true 죽은방 제거
                
                int index = _listings.FindIndex(x => x._roomInfo.Name == info.Name);

                if(index != -1){

                    Destroy(_listings[index].gameObject);
                    _listings.RemoveAt(index);
                }
            }
            else{ // removedList = false

                int index = _listings.FindIndex(x => x._roomInfo.Name == info.Name);

                if(index == -1){

                    RoomHolder roomHolder = Instantiate(_roomHolder, _content);
                    if(roomHolder != null){

                        roomHolder.SetRoomInfo(info);
                        _listings.Add(roomHolder);
                    }
                }
                else{


                }
            }

        }
    }

    //roomList 초기화를 위한 메서드
    public void DestroyChildren(Transform t, bool destroyImmd = false){

        foreach(Transform child in t){

            if(destroyImmd){

                DestroyImmediate(child.gameObject);
            }
            else{

                Destroy(child.gameObject);
            }
        }
    }
}
