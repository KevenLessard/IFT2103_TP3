using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class OptionMenu : MonoBehaviour
{
    [SerializeField] private GameObject mainOptionCanvas;

    [SerializeField] private GameObject controlsOptionCanvas;

    [SerializeField] private Button returnButton;
    
    [SerializeField] private TextMeshProUGUI pressEscText;

    public void OnQuitGameClick()
    {
        Application.Quit();
    }

    public void OnControlsClick()
    {
        mainOptionCanvas.SetActive(false);
        controlsOptionCanvas.SetActive(true);
    }

    public void OnReturnClick()
    {
        if (controlsOptionCanvas.activeSelf)
        {
            controlsOptionCanvas.SetActive(false);
            mainOptionCanvas.SetActive(true);
        }
        else
        {
            if (TitleController.Instance)
            {
                TitleController.Instance.ShowTitleMenu();
                Destroy(gameObject);
            }
            else
            {
                mainOptionCanvas.SetActive(false);
                controlsOptionCanvas.SetActive(false);
                returnButton.gameObject.SetActive(false);
                pressEscText.gameObject.SetActive(true);
            }
        }
    }
}