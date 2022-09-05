using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    public Text[] _buttonList;
    private string _playerSide;

    private void Awake() {
        SetGameControllerReferenceOnButtons();
        _playerSide = "X";
    }
    private void SetGameControllerReferenceOnButtons(){
        for(int i = 0; i < _buttonList.Length; i++){
            _buttonList[i].GetComponentInParent<GridSpace>().SetGameControllerReference(this);
        }
    }

    public string GetPlayerSide(){
        return _playerSide;
    }

    public void EndTurn(){
        if(_buttonList[0].text == _playerSide && _buttonList[1].text == _playerSide && _buttonList[2].text == _playerSide){
            GameOver();
        }
    }

    void GameOver(){
        for(int i = 0; i < _buttonList.Length; i++){
            _buttonList[i].GetComponentInParent<Button>().interactable = false;
        }
    }
}
