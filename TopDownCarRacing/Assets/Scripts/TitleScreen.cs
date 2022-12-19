using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class TitleScreen : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI pressAnyKeyText;

    [SerializeField] private Button startGameButton;

    [SerializeField] private Button optionButton;
    
    [SerializeField] private Button onlineButton;

    [SerializeField] private GameObject layout;

    private bool isKeyPressed;
    
    // Start is called before the first frame update
    void Start()
    {
        isKeyPressed = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (!isKeyPressed)
        {
            if (Input.anyKey)
            {
                isKeyPressed = true;
                pressAnyKeyText.enabled = false;
                layout.SetActive(true);
                TitleMusicManager.Instance.StartMusic();
            }
        }
    }
    
    public void OnStartGameClick()
    {
        TitleController.Instance.StartGame();
    }

    public void OnStartOnlineClick()
    {
        TitleController.Instance.StartOnlineGame();
    }

    public void OnOptionClick()
    {
        TitleController.Instance.OpenOptionMenu();
    }
}
