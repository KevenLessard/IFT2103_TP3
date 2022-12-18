using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Car : MonoBehaviour
{
    [SerializeField] private CarParts _carParts;

    [SerializeField] private SpriteRenderer carFrame;

    [SerializeField] private SpriteRenderer carWindow;
    
    // Start is called before the first frame update
    void Start()
    {
        carFrame = _carParts.carFrame;
        carWindow = _carParts.window;
    }
}
