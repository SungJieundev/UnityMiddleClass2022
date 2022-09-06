using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class Player{
    public Image _Panel;
    public Text _text;

    public Button _button;
}

[System.Serializable]
public class PlayerColor{
    public Color _panelColor;
    public Color _textColor;
}

public class GameController : MonoBehaviour
{
    public Text[] _buttonList;
    public GameObject _gameOverPanel;
    public Text _gameOverText;
    private int _moveCount;
    public GameObject _restartButton;

    public Player _playerX;
    public Player _playerO;
    public PlayerColor _activePlayerColor;
    public PlayerColor _inactivePlayerColor;

    public GameObject _textInfo;

    private string _playerSide;

    private void Awake() {
        SetGameControllerReferenceOnButtons();
        _gameOverPanel.SetActive(false);
        _restartButton.SetActive(false);
        _moveCount = 0;
        SetPlayerColor(_playerX, _playerO);
    }
    private void SetGameControllerReferenceOnButtons(){
        for(int i = 0; i < _buttonList.Length; i++){
            _buttonList[i].GetComponentInParent<GridSpace>().SetGameControllerReference(this);
        }
    }

    public void StartGame(){
        _textInfo.SetActive(false);
    }

    public void SetStartingSide(string startingSide){
        _playerSide = startingSide;
        if(_playerSide == "X"){
            SetPlayerColor(_playerX, _playerO);
        }
        else{
            SetPlayerColor(_playerO, _playerX);
        }
    }

    public string GetPlayerSide(){
        return _playerSide;
    }

    public void ChangeSides(){
        _playerSide = (_playerSide == "X") ? "O" : "X"; 
        if(_playerSide == "X"){
            SetPlayerColor(_playerX, _playerO);
        }
        else{
            SetPlayerColor(_playerO, _playerX);
        }

        StartGame();
    }

    void SetPlayerColor(Player newPlayer, Player oldPlayer){
        newPlayer._Panel.color = _activePlayerColor._panelColor;
        newPlayer._text.color = _activePlayerColor._textColor;
        oldPlayer._Panel.color = _inactivePlayerColor._panelColor;
        oldPlayer._text.color = _inactivePlayerColor._textColor;
    }

    public void EndTurn(){
        _moveCount++;
        if(CheckMatch()){
            GameOver(_playerSide);
        }

        if(_moveCount >= 9){
            GameOver("draw");
        }

        ChangeSides();
    }

    private bool CheckWin(int i, int j, int k){
        bool matched = (_buttonList[i].text == _playerSide && _buttonList[j].text == _playerSide && _buttonList[k].text == _playerSide);
        return matched;
    }

    private bool CheckMatch(){
        return CheckWin(0,1,2) || CheckWin(3,4,5) || CheckWin(6,7,8) 
            || CheckWin(0,3,6) || CheckWin(1,4,7) || CheckWin(2,5,8)
            || CheckWin(0,4,8) || CheckWin(2,4,6);
    }

    void GameOver(string winningPlayer){
        for(int i = 0; i < _buttonList.Length; i++){
            _buttonList[i].GetComponentInParent<Button>().interactable = false;
        }
        _gameOverPanel.SetActive(true);

        if(winningPlayer == "draw"){
            _gameOverText.text = "Draw!";
        }
        else{
            _gameOverText.text = winningPlayer + "  Wins!";
        }

        _restartButton.SetActive(true);
    }

    public void RestartGame(){
        _playerSide = "X";
        _moveCount = 0;
        _gameOverPanel.SetActive(false);
        _restartButton.SetActive(false);

        SetPlayerColor(_playerX, _playerO);

        for(int i = 0; i < _buttonList.Length; i++){
            _buttonList[i].text = "";
            _buttonList[i].GetComponentInParent<Button>().interactable = true;
        }
    }

}
