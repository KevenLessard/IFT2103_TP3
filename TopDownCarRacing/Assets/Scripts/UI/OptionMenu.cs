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
    
    [SerializeField] private GameObject carsOptionCanvas;
    
    [SerializeField] private GameObject levelSelectCanvas;
    
    [SerializeField] private GameObject resolutionCanvas;
    
    [SerializeField] private GameObject loadScreenCanvas;

    [SerializeField] private Button returnButton;
    
    [SerializeField] private TextMeshProUGUI pressEscText;

    [SerializeField] private Slider slider;

    [SerializeField] private Button modifyCarButton;

    private void Start()
    {
        if (!TitleController.Instance)
        {
            modifyCarButton.gameObject.SetActive(false);
            GameObject.Find("MusicManager").GetComponent<DynamicMusicManager>().SetSliderValues();
        }
        else
        {
            GameObject.Find("AudioManager").GetComponent<TitleMusicManager>().SetSliderValues();
        }

    }
    
    public void OnQuitGameClick()
    {
        Application.Quit();
    }

    public void OnMainMenuClick()
    {
        LoadScene("Title_screen");
    }

    public void OnControlsClick()
    {
        mainOptionCanvas.SetActive(false);
        controlsOptionCanvas.SetActive(true);
    }

    public void OnCarsClick()
    {
        mainOptionCanvas.SetActive(false);
        carsOptionCanvas.SetActive(true);
    }

    public void OnLevelSelectClick()
    {
        mainOptionCanvas.SetActive(false);
        levelSelectCanvas.SetActive(true);
    }

    public void OnResolutionClick()
    {
        mainOptionCanvas.SetActive(false);
        resolutionCanvas.SetActive(true);
    }

    public void UpdateResolution(Vector2 newResolution, bool fullscreen)
    {
        Screen.SetResolution((int) newResolution.x, (int) newResolution.y, fullscreen);
    }

    public void OnReturnClick()
    {
        if (controlsOptionCanvas.activeSelf || levelSelectCanvas.activeSelf || carsOptionCanvas.activeSelf)
        {
            levelSelectCanvas.SetActive(false);
            controlsOptionCanvas.SetActive(false);
            carsOptionCanvas.SetActive(false);
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
                carsOptionCanvas.SetActive(false);
                returnButton.gameObject.SetActive(false);
                resolutionCanvas.gameObject.SetActive(false);
                pressEscText.gameObject.SetActive(true);
            }
        }
    }
    public void LoadScene(string level)
    {
        Time.timeScale = 1;
        StartCoroutine(Load(level));
    }
    
    private IEnumerator Load(string level)
    {        
        levelSelectCanvas.SetActive(false);
        controlsOptionCanvas.SetActive(false);
        mainOptionCanvas.SetActive(false);
        carsOptionCanvas.SetActive(false);
        loadScreenCanvas.SetActive(true);
        AsyncOperation handle = SceneManager.LoadSceneAsync(level);
        while (!handle.isDone)
        {
            float progress = Mathf.Clamp01(handle.progress / .9f);
            slider.value = progress;
            yield return null;
        }
    }
}