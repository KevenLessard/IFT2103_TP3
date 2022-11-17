using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleController : MonoBehaviour
{
    [SerializeField] private GameObject optionMenu;

    [SerializeField] private GameObject titleScreen;

    public static TitleController Instance;

    private GameObject _titleScreenInstance;

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
        StartCoroutine(Load());
    }
    
    private IEnumerator Load()
    {
        AsyncOperation handle = SceneManager.LoadSceneAsync("Level_one");
        while (!handle.isDone)
        {
            //TO DO update UI with progress
            //handle.progress
            yield return null;
        }
    }
}
