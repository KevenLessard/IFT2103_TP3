using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/InputManager", order = 1)]
public class Inputs : ScriptableObject
{
    public KeyCode[] _playerInputs;
}
