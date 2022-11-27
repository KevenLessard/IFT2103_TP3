using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class ResolutionOption : MonoBehaviour
{
    [SerializeField] private OptionMenu optionMenu;

    [SerializeField] private TMP_Dropdown dropdown;

    [SerializeField] private Toggle fullscreenToggle;

    private List<Resolution> _resolutions;
    private List<Resolution> _actualResolutions;

    private void Start()
    {
        _resolutions = new List<Resolution>(Screen.resolutions);
        _actualResolutions = new List<Resolution>();
        foreach (Resolution res in _resolutions)
        {
            if (dropdown.options.SingleOrDefault((data => data.text == res.width.ToString() + " x " + res.height.ToString())) == null)
            {
                dropdown.options.Add(new TMP_Dropdown.OptionData(res.width.ToString() + " x " + res.height.ToString()));
                _actualResolutions.Add(res);
            }
        }
    }
    public void UpdateResolutionOnClick()
    {
        Vector2 newResolution = new Vector2(_actualResolutions[dropdown.value].width, _actualResolutions[dropdown.value].height);

        optionMenu.UpdateResolution(newResolution, fullscreenToggle.isOn);
    }
}
