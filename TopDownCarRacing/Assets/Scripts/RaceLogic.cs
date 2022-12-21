using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;
using UnityEngine.SceneManagement;


public class RaceLogic : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI playerOneText;
    [SerializeField] private TextMeshProUGUI playerTwoText;
    [SerializeField] private TextMeshProUGUI winText;
    [SerializeField] private GameObject optionMenu;
    [SerializeField] private GameObject[] checkpoints;
    [SerializeField] private CountdownLights countdownLights;
    [SerializeField] private GameObject celebrationZone;
    
    private GameObject _optionMenuInstance;
    


    [SerializeField] private int numberOfLaps;

    private int _currentLapOne;
    private int _currentLapTwo;
    private int _currentCheckpointOne;
    private int _currentCheckpointTwo;

    private int _numberOfCheckpoints;

    private float _timeOne;
    private float _timeTwo;

    private float _oneCurrentBest;

    private float _twoCurrentBest;

    private bool _isMenuOpen;

    private bool _isRaceOver;

    private bool _isRaceStarted;

    void Start()
    {
        _currentLapOne = 0;
        _currentLapTwo = 0;
        _currentCheckpointOne = 0;
        _currentCheckpointTwo = 0;
        _numberOfCheckpoints = checkpoints.Length;
        _oneCurrentBest = float.MaxValue;
        _twoCurrentBest = float.MaxValue;
        winText.enabled = false;
        _isRaceOver = false;
        playerOneText.SetText($"Lap: {_currentLapOne}/{numberOfLaps}\nLast lap:\n--\nBest lap:\n--");
        playerTwoText.SetText($"Lap: {_currentLapTwo}/{numberOfLaps}\nLast lap:\n--\nBest lap:\n--");

        StartCoroutine(StartRace());
    }

    // Update is called once per frame
    void Update()
    {
        if (!_isRaceStarted)
        {
            return;
        }
        DynamicMusicManager.Instance.ChangeSong(_currentLapOne);
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
    GameObject celebration = ParticlePool.instance.GetPooledCelebration();
        if (pPlayer == "Player_one")
        {
            if (_currentCheckpointOne != _numberOfCheckpoints)
            {
                if (_currentLapOne == 0)
                {
                    _currentLapOne++;
                    playerOneText.SetText($"Lap: {_currentLapOne}/{numberOfLaps}\nLast lap:\n--\nBest lap:\n--");
                }

                return;
            }

            _currentCheckpointOne = 0;
            _currentLapOne++;

            if (_currentLapOne == numberOfLaps + 1)
            {
                celebration.transform.position = celebrationZone.transform.position;
                celebration.SetActive(true);
                DynamicMusicManager.Instance.playVictoryJingle();
                winText.SetText("Player one wins!");
                winText.color = new Color32(173, 75, 55, 255);
                winText.enabled = true;
                StartCoroutine(WaitBeforeEnd(3));
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
            _timeOne = 0;
        }
        else
        {
            if (_currentCheckpointTwo != _numberOfCheckpoints)
            {
                if (_currentLapTwo == 0)
                {
                    _currentLapTwo++;
                    playerTwoText.SetText($"Lap: {_currentLapTwo}/{numberOfLaps}\nLast lap:\n--\nBest lap:\n--");
                }
                return;
            }

            _currentCheckpointTwo = 0;
            _currentLapTwo++;

            if (_currentLapTwo == numberOfLaps + 1)
            {

                celebration.transform.position = celebrationZone.transform.position;
                celebration.SetActive(true);
                DynamicMusicManager.Instance.playVictoryJingle();
                winText.SetText("Player two wins!");
                winText.color = new Color32(52, 65, 147, 255);
                winText.enabled = true;
                StartCoroutine(WaitBeforeEnd(3));
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
            _timeTwo = 0;
        }
    }

    public void UpdateCheckPoints(string pPlayer, Checkpoint pCheckpoint)
    {
        if (pPlayer == "Player_one")
        {
            if (_currentCheckpointOne < _numberOfCheckpoints)
            {
                if (pCheckpoint.name == checkpoints[_currentCheckpointOne].name)
                {
                    _currentCheckpointOne++;
                }
            }
        }
        else
        {
            if (_currentCheckpointTwo < _numberOfCheckpoints)
            {
                if (pCheckpoint.name == checkpoints[_currentCheckpointTwo].name)
                {
                    _currentCheckpointTwo++;
                }
            }
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

    private IEnumerator StartRace()
    {
        _isRaceStarted = false;
        Time.timeScale = 0;
        //RaceAudioManager.Instance.StartAmbientSong();
        DynamicMusicManager.Instance.StartAmbientSong();
        yield return StartCoroutine(countdownLights.PlayAnimation());
        //RaceAudioManager.Instance.StartMusic();
        DynamicMusicManager.Instance.ChangeSong(1);
        Time.timeScale = 1;
        _isRaceStarted = true;
    }
}