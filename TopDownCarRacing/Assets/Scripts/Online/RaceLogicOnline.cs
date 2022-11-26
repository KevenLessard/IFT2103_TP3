using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;
using Unity.Netcode;
using Unity.VisualScripting;
using UnityEngine.SceneManagement;


public class RaceLogicOnline : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI playerOneText;
    [SerializeField] private TextMeshProUGUI playerTwoText;
    [SerializeField] private TextMeshProUGUI winText;
    [SerializeField] private GameObject optionMenu;
    private GameObject _optionMenuInstance;

    [SerializeField] private int numberOfLaps;

    private int _currentLapOne;
    private int _currentLapTwo;

    private float _timeOne;
    private float _timeTwo;

    private float _oneCurrentBest;

    private float _twoCurrentBest;

    private bool _isMenuOpen;
    private bool _isRaceOver;
    private int _counter;
    private bool _noWinner = true;


    // Start is called before the first frame update
    void Start()
    {
        int _counter = 0;
        _isRaceOver = false;
        _currentLapOne = 0;
        _currentLapTwo = 0;
        _oneCurrentBest = float.MaxValue;
        _twoCurrentBest = float.MaxValue;
        winText.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        _timeOne += Time.deltaTime;
        _timeTwo += Time.deltaTime;

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (_isMenuOpen)
            {
                ResumeGame();
            }
            else
            {
                PauseGame();
            }
        }

        if (_isRaceOver)
        {
            SceneManager.LoadSceneAsync("Title_screen");
        }
    }

    public void UpdateText(string pPlayer)
    {
        if (pPlayer == "Player_one")
        {
            _currentLapOne++;

            if (_currentLapOne == 1)
            {
                playerOneText.SetText($"Lap: {_currentLapOne}/{numberOfLaps}\nLast lap:\n--\nBest lap:\n--");
            }
            else
            {
                if (_currentLapOne == numberOfLaps + 1 && _noWinner)
                {
                    winText.SetText("You won!");
                    winText.color = new Color32(173, 75, 55, 255);
                    winText.enabled = true;

                    if (NetworkManager.Singleton.IsHost)
                    {
                        NetworkManager.Singleton.StopAllCoroutines();
                        StartCoroutine(WaitBeforeEnd(3));
                    }

                    else if (NetworkManager.Singleton.IsClient)
                    {
                        StartCoroutine(WaitBeforeEnd(5));
                    }

                    _noWinner = false;

                }
                else
                {
                    if (_timeOne < _oneCurrentBest)
                    {
                        _oneCurrentBest = _timeOne;
                    }

                    playerOneText.SetText(
                        $"Lap: {_currentLapOne}/{numberOfLaps}\nLast lap:\n{Math.Round(_timeOne, 2)}\nBest lap:\n{Math.Round(_oneCurrentBest, 2)}");
                }
            }


            _timeOne = 0;
        }
        else
        {
            _currentLapTwo++;

            if (_currentLapTwo == 1)
            {
                playerTwoText.SetText($"Lap: {_currentLapTwo}/{numberOfLaps}\nLast lap:\n--\nBest lap:\n--");
            }
            else
            {
                if (_currentLapTwo == numberOfLaps + 1 && _noWinner)
                {
                    winText.SetText("You lost");
                    winText.color = new Color32(52, 65, 147, 255);
                    winText.enabled = true;
                    
                    if (NetworkManager.Singleton.IsHost)
                    {
                        NetworkManager.Singleton.StopAllCoroutines();
                        StartCoroutine(WaitBeforeEnd(3));
                    }

                    else if (NetworkManager.Singleton.IsClient)
                    {
                        StartCoroutine(WaitBeforeEnd(5));
                    }

                    _noWinner = false;

                }
                else
                {
                    if (_timeTwo < _twoCurrentBest)
                    {
                        _twoCurrentBest = _timeTwo;
                    }

                    playerTwoText.SetText(
                        $"Lap: {_currentLapTwo}/{numberOfLaps}\nLast lap:\n{Math.Round(_timeTwo, 2)}\nBest lap:\n{Math.Round(_twoCurrentBest, 2)}");
                }
            }

            _timeTwo = 0;
        }
    }

    private void PauseGame()
    {
        Time.timeScale = 0;
        _optionMenuInstance = Instantiate(optionMenu, transform);
        _isMenuOpen = true;
    }

    private void ResumeGame()
    {
        Destroy(_optionMenuInstance);
        Time.timeScale = 1;
        _isMenuOpen = false;
    }

    IEnumerator WaitBeforeEnd(int time)
    {
        yield return new WaitForSeconds(time);

        _isRaceOver = true;
    }
}