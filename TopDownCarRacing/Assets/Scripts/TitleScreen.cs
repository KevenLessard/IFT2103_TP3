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
                startGameButton.gameObject.SetActive(true);
                optionButton.gameObject.SetActive(true);
            }
        }
    }
    
    public void OnStartGameClick()
    {
        TitleController.Instance.StartGame();
    }

    public void OnOptionClick()
    {
        TitleController.Instance.OpenOptionMenu();
    }
}
