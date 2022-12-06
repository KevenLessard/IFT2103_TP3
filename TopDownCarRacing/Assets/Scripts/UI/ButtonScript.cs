using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ButtonScript : MonoBehaviour
{
    public Color defaultColor;
    public Color hoverColor;

    private Image _image;

    private Color _buttonColor;
    private float _colorSwitchTime;

    private Coroutine _hoverCoroutine;

    private bool _isLocked;

    private void Awake()
    {
        _image = GetComponent<Image>();
        _image.color = defaultColor;
        _colorSwitchTime = 0.3f;
    }

    private void Update()
    {
        if (_isLocked)
        {
            if (Input.anyKeyDown)
            {
                _isLocked = false;
                OnPointerExit();
            }
        }
    }

    public void OnPointerEnter()
    {
        if (_isLocked)
        {
            return;
        }
        if (_hoverCoroutine == null)
        {
            _hoverCoroutine = StartCoroutine(ColorSwitch(_image.color, hoverColor));
        }
        else
        {
            StopCoroutine(_hoverCoroutine);
            _hoverCoroutine = StartCoroutine(ColorSwitch(_image.color, hoverColor));
        }
    }

    public void OnPointerExit()
    {
        if (_isLocked)
        {
            return;
        }
        if (_hoverCoroutine == null)
        {
            _hoverCoroutine = StartCoroutine(ColorSwitch(_image.color, defaultColor));
        }
        else
        {
            StopCoroutine(_hoverCoroutine);
            _hoverCoroutine = StartCoroutine(ColorSwitch(_image.color, defaultColor));
        }
    }

    private IEnumerator ColorSwitch(Color startingColor, Color endColor)
    {
        float timeElapsed = 0;
        while (timeElapsed < _colorSwitchTime)
        {
            _buttonColor = Color.Lerp(startingColor, endColor, Easing(0, 1, timeElapsed / _colorSwitchTime));
            _image.color = _buttonColor;
            timeElapsed += Time.unscaledDeltaTime;
            yield return null;
        }
    }
    private float Easing(float start, float end, float value)
    {
        end -= start;
        return -end * value * (value - 2) + start;
    }

    public void OnEnable()
    {
        _image.color = defaultColor;
    }

    public void OnClick()
    {
        _image.color = hoverColor;
        _isLocked = true;
    }
}