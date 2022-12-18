using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "CarData", menuName = "ScriptableObjects/CarParts", order = 2)]
public class CarParts : ScriptableObject
{
    public SpriteRenderer carFrame;
    public SpriteRenderer window;
}
