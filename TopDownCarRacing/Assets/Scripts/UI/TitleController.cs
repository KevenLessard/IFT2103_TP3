using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class TitleController : MonoBehaviour
{

    [SerializeField] private GameObject optionMenu;

    [SerializeField] private GameObject titleScreen;

    public GameObject loadingScreen;

    public Slider slider;

    public static TitleController Instance;

    private GameObject _titleScreenInstance;

    public string levelLocal = "Level_one";

    public string levelOnline = "OnlineLevel";

    private void Awake()
    {
        Instance = FindObjectOfType<TitleController>();
    }

    private void Start()
    {
        _titleScreenInstance = Instantiate(titleScreen, transform);
    }

    public void OpenOptionMenu()
    {
        _titleScreenInstance.SetActive(false);
        Instantiate(Instance.optionMenu, transform);
    }

    public void ShowTitleMenu()
    {
        _titleScreenInstance.SetActive(true);
    }

    public void StartGame()
    {
        StartCoroutine(Load(levelLocal));
    }
    
    public void StartOnlineGame()
    {
        StartCoroutine(Load(levelOnline));
    }
    
    private IEnumerator Load(string level)
    {
        AsyncOperation handle = SceneManager.LoadSceneAsync(level);
        _titleScreenInstance.SetActive(false);
        loadingScreen.SetActive(true);
        
        while (!handle.isDone)
        {
            float progress = Mathf.Clamp01(handle.progress / .9f);
            slider.value = progress;
            yield return null;
        }
    }
}
