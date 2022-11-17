using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Serialization;
using UnityEngine.UI;

public class TitleScreen : MonoBehaviour
{
    public TextMeshProUGUI pressAnyKeyText;

    public Button startGameButton;

    public Button optionButton;

    public GameObject optionMenu;

    [FormerlySerializedAs("InputManager")] public Inputs inputs;

    private bool isKeyPressed;
    // Start is called before the first frame update
    void Start()
    {
        isKeyPressed = false;
        
        //Set default control
        inputs._playerOneInputs[0] = KeyCode.W;
        inputs._playerOneInputs[1] = KeyCode.S;
        inputs._playerOneInputs[2] = KeyCode.D;
        inputs._playerOneInputs[3] = KeyCode.A;

        inputs._playerTwoInputs[0] = KeyCode.UpArrow;
        inputs._playerTwoInputs[1] = KeyCode.DownArrow;
        inputs._playerTwoInputs[2] = KeyCode.RightArrow;
        inputs._playerTwoInputs[3] = KeyCode.LeftArrow;
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
        StartCoroutine(Load());
    }

    public void OnOptionClick()
    {
        optionMenu.gameObject.SetActive(true);
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
