using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class OptionMenu : MonoBehaviour
{
    [SerializeField] private GameObject mainOptionCanvas;
    
    [SerializeField] private GameObject controlsOptionCanvas;
    public void OnQuitGameClick()
    {
        Application.Quit();
    }

    public void OnControlsClick()
    {
        
    }

    public void OnReturnClick()
    {
        if (TitleController.Instance)
        {
            TitleController.Instance.ShowTitleMenu();
        }
        Destroy(gameObject);
    }
}
