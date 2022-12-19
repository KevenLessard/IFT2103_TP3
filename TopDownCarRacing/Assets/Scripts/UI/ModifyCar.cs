using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class ModifyCar : MonoBehaviour
{
    [SerializeField] private CarParts _carParts;

    [SerializeField] private FlexibleColorPicker _colorPicker;

    [SerializeField] private Slider widthSlider;
    
    [SerializeField] private Slider heightSlider;

    [SerializeField] private TMP_Dropdown paintDropdown;
    [SerializeField] private TMP_Dropdown premadeDropdown;

    [SerializeField] private Sprite flames;
    [SerializeField] private Sprite strips;
    [SerializeField] private Sprite triangle;

    [SerializeField] private CarParts premadeOne;
    [SerializeField] private CarParts premadeTwo;
    public void OnCarColorChangeClick()
    {
        _carParts.frameColor = _colorPicker.color;
    }

    public void OnWindowColorChangeClick()
    {
        _carParts.windowColor = _colorPicker.color;
    }

    public void OnPaintColorChangeClick()
    {
        _carParts.paintColor = _colorPicker.color;
    }

    public void OnWidthChange()
    {
        _carParts.carScale.x = widthSlider.value;
    }
    
    public void OnHeightChange()
    {
        _carParts.carScale.y = heightSlider.value;
    }

    public void OnPaintChange()
    {
        switch (paintDropdown.value)
        {
            case 0:
                _carParts.carPaint = strips;
                break;
            case 1:
                _carParts.carPaint = flames;
                break;
            case 2:
                _carParts.carPaint = triangle;
                break;
            default:
                break;
        }
    }

    public void OnPremadeChange()
    {
        switch (premadeDropdown.value)
        {
            case 0:
                _carParts.carPaint = premadeOne.carPaint;
                _carParts.windowColor = premadeOne.windowColor;
                _carParts.paintColor = premadeOne.paintColor;
                _carParts.carScale = premadeOne.carScale;
                _carParts.frameColor = premadeOne.frameColor;
                break;
            case 1:
                _carParts.carPaint = premadeTwo.carPaint;
                _carParts.windowColor = premadeTwo.windowColor;
                _carParts.paintColor = premadeTwo.paintColor;
                _carParts.carScale = premadeTwo.carScale;
                _carParts.frameColor = premadeTwo.frameColor;
                break;
            default:
                break;
        }
    }
}
