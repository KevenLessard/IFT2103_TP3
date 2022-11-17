using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/InputManager", order = 1)]
public class Inputs : ScriptableObject
{
    public KeyCode[] _playerOneInputs;

    public KeyCode[] _playerTwoInputs;
    
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

    public KeyCode[] GetInputs(string pPlayer)
    {
        if (pPlayer == "Player_one")
        {
            return _playerOneInputs;
        }

        return _playerTwoInputs;
    }
}
