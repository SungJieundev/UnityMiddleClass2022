using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class PlayerListMenu : MonoBehaviourPunCallbacks
{   
    [SerializeField] private Transform _content; //scrollView
    [SerializeField] private PlayerHolder _playerHolder;
    private List<PlayerHolder> _listings = new List<PlayerHolder>();

    public override void OnEnable()
    {
        base.OnEnable();
        GetCurrentRoomPlayers();
    }

    public override void OnDisable()
    {
        base.OnDisable();

        foreach(Transform child in _content){

            Destroy(child.gameObject);
        }

        _listings.Clear();
    }
    private void GetCurrentRoomPlayers(){
        
        foreach(KeyValuePair<int, Player> playerInfo in PhotonNetwork.CurrentRoom.Players){


        }
    }
}
