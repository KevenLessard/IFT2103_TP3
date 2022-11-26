using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class OptionMenu : MonoBehaviour
{
    [SerializeField] private GameObject mainOptionCanvas;

    [SerializeField] private GameObject controlsOptionCanvas;
    
    [SerializeField] private GameObject levelSelectCanvas;

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

    public void OnLevelSelectClick()
    {
        mainOptionCanvas.SetActive(false);
        levelSelectCanvas.SetActive(true);
    }

    public void OnReturnClick()
    {
        if (controlsOptionCanvas.activeSelf || levelSelectCanvas.activeSelf)
        {
            levelSelectCanvas.SetActive(false);
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
    public void LoadScene(string level)
    {
        SceneManager.LoadScene(level);
        Time.timeScale = 1;
    }
}