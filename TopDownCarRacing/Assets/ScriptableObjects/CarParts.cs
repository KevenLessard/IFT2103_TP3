using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "CarData", menuName = "ScriptableObjects/CarParts", order = 2)]
public class CarParts : ScriptableObject
{
    public Vector3 carScale;
    public Color frameColor;
    public Color windowColor;
    public Sprite carPaint;
    public Color paintColor;
}
