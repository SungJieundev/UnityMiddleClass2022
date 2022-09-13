using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GridSpace : MonoBehaviour
{
    public Button _button;
    public Text _buttonText;
    public string _playerSide;
    private GameController _gameController;

    public void SetGameControllerReference(GameController gameController){
        this._gameController = gameController;
    }

    public void SetSpace(){
        
        if(_gameController._isPlayerMove == true){
            
            _buttonText.text = _gameController.GetPlayerSide(); 
            _button.interactable = false;
            _gameController.EndTurn();
        }
    }

}
