using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class Player
{
    public Image _Panel;
    public Text _text;

    public Button _button;
}

[System.Serializable]
public class PlayerColor
{
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
    private string _computerSide;

    public bool _isPlayerMove;
    public float _delay;

    private void Awake()
    {
        SetGameControllerReferenceOnButtons();
        _gameOverPanel.SetActive(false);
        _restartButton.SetActive(false);
        _moveCount = 0;
        SetPlayerColor(_playerX, _playerO);
        _isPlayerMove = true;
    }

    private void Update()
    {

        if (_isPlayerMove == false)
        {
            _delay += _delay * Time.deltaTime;
            if (_delay >= 100)
            {

                int v = Random.Range(0, 9);

                if (_buttonList[v].GetComponentInParent<Button>().interactable)
                {

                    _buttonList[v].text = _computerSide;
                    _buttonList[v].GetComponentInParent<Button>().interactable = false;
                    EndTurn();
                }
            }
        }
    }

    private void SetGameControllerReferenceOnButtons()
    {
        for (int i = 0; i < _buttonList.Length; i++)
        {
            _buttonList[i].GetComponentInParent<GridSpace>().SetGameControllerReference(this);
        }
    }

    public void StartGame()
    {
        _textInfo.SetActive(false);
        SetBoardInteractable(true);
        SetPlayerButtons(false);
    }

    public void SetStartingSide(string startingSide)
    {
        _playerSide = startingSide;
        if (_playerSide == "X")
        {
            _computerSide = "O";
            SetPlayerColor(_playerX, _playerO);
        }
        else
        {
            _computerSide = "X";
            SetPlayerColor(_playerO, _playerX);
        }
    }

    public string GetPlayerSide()
    {
        return _playerSide;
    }

    public string GetComputerSide(){
        return _computerSide;

    }

    public void ChangeSides()
    {
        //_playerSide = (_playerSide == "X") ? "O" : "X";

        _isPlayerMove = (_isPlayerMove == true) ? false : true;

        if (_playerSide == "X")
        {
            SetPlayerColor(_playerX, _playerO);
        }
        else
        {
            SetPlayerColor(_playerO, _playerX);
        }

        StartGame();
    }

    void SetPlayerColor(Player newPlayer, Player oldPlayer)
    {
        newPlayer._Panel.color = _activePlayerColor._panelColor;
        newPlayer._text.color = _activePlayerColor._textColor;
        oldPlayer._Panel.color = _inactivePlayerColor._panelColor;
        oldPlayer._text.color = _inactivePlayerColor._textColor;
    }

    public void EndTurn()
    {
        _moveCount++;
        _delay = 10;
        if (CheckMatch(_playerSide))
        {
            GameOver(_playerSide);
        }

        if(CheckMatch(_computerSide)){
            GameOver(_computerSide);
        }

        if (_moveCount >= 9)
        {
            GameOver("draw");
        }

        ChangeSides();
    }

    private bool CheckWin(int i, int j, int k, string turn)
    {
        bool matched = (_buttonList[i].text == turn 
                        && _buttonList[j].text == turn 
                        && _buttonList[k].text == turn);
        return matched;
    }

    private bool CheckMatch(string turn)
    {
        return CheckWin(0, 1, 2, turn) || CheckWin(3, 4, 5, turn) || CheckWin(6, 7, 8, turn)
            || CheckWin(0, 3, 6, turn) || CheckWin(1, 4, 7, turn) || CheckWin(2, 5, 8, turn)
            || CheckWin(0, 4, 8, turn) || CheckWin(2, 4, 6, turn);
    }

    void GameOver(string winningPlayer)
    {
        SetBoardInteractable(false);
        _gameOverPanel.SetActive(true);

        if (winningPlayer == "draw")
        {
            _gameOverText.text = "Draw!";
        }
        else
        {
            _gameOverText.text = winningPlayer + "  Wins!";
        }

        _restartButton.SetActive(true);
    }

    public void RestartGame()
    {
        _playerSide = "X";
        _moveCount = 0;
        _gameOverPanel.SetActive(false);
        _restartButton.SetActive(false);
        SetPlayerButtons(true);
        SetBoardInteractable(true);

        _isPlayerMove = true;

        SetPlayerColor(_playerX, _playerO);

        for (int i = 0; i < _buttonList.Length; i++)
        {
            _buttonList[i].text = "";
        }
    }

    public void SetBoardInteractable(bool toggle)
    {
        for (int i = 0; i < _buttonList.Length; i++)
        {

            _buttonList[i].GetComponentInParent<Button>().interactable = toggle;
        }
    }

    void SetPlayerButtons(bool toggle)
    {
        _playerX._button.interactable = toggle;
        _playerO._button.interactable = toggle;
    }
}
