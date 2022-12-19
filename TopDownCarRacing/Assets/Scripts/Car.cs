using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Car : MonoBehaviour
{
    [SerializeField] private CarParts _carParts;

    [SerializeField] private SpriteRenderer carFrame;

    [SerializeField] private SpriteRenderer carWindow;
    
    [SerializeField] private SpriteRenderer carPaint;
    
    // Start is called before the first frame update
    void Start()
    {
        carFrame.color = _carParts.frameColor;
        carWindow.color = _carParts.windowColor;
        carPaint.sprite= _carParts.carPaint;
        carPaint.color = _carParts.paintColor;
        transform.localScale = _carParts.carScale;
    }
}
