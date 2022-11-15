using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    private KeyCode[] _playerOneInputs;

    private KeyCode[] _playerTwoInputs;

    private void Start()
    {
        _playerOneInputs = new KeyCode[4];
        _playerOneInputs[0] = KeyCode.W;
        _playerOneInputs[1] = KeyCode.S;
        _playerOneInputs[2] = KeyCode.D;
        _playerOneInputs[3] = KeyCode.A;

        _playerTwoInputs = new KeyCode[4];
        _playerTwoInputs[0] = KeyCode.UpArrow;
        _playerTwoInputs[1] = KeyCode.DownArrow;
        _playerTwoInputs[2] = KeyCode.RightArrow;
        _playerTwoInputs[3] = KeyCode.LeftArrow;
    }

    public Vector2 GetInput(string pPlayer)
    {
        Vector2 playerInputs = Vector2.zero;
        KeyCode[] playerNumber = _playerOneInputs;
        
        if (pPlayer == "Player_two")
        {
            playerNumber = _playerTwoInputs;
        }

        if (Input.GetKey(playerNumber[0]))
        {
            playerInputs.x += 1;
        }

        if (Input.GetKey(playerNumber[1]))
        {
            playerInputs.x -= 1;
        }

        if (Input.GetKey(playerNumber[2]))
        {
            playerInputs.y -= 1;
        }

        if (Input.GetKey(playerNumber[3]))
        {
            playerInputs.y += 1;
        }

        return playerInputs;
    }

    public void changeInputs(string pPlayer, KeyCode[] pNewInputs)
    {
        if (pPlayer == "Player_one")
        {
            _playerOneInputs = pNewInputs;
        }
        else
        {
            _playerTwoInputs = pNewInputs;
        }
    }
}
