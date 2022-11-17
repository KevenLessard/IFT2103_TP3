using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OptionMenu : MonoBehaviour
{
    public GameObject previousUI;

    public Button controlsButton;

    public Button quitGameButton;

    public Button returnButton;

    private void OnEnable()
    {
        previousUI.gameObject.SetActive(false);
    }

    public void OnQuitGameClick()
    {
        Application.Quit();
    }

    public void OnControlsClick()
    {
        
    }

    public void OnReturnClick()
    {
        
    }
}
