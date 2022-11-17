using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;


public class RaceLogic : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI player_one_text;
    [SerializeField] private TextMeshProUGUI player_two_text;
    [SerializeField] private TextMeshProUGUI winText;

    [SerializeField] private int numberOfLaps;

    private int currentLapOne;
    private int currentLapTwo;

    private float timeOne;
    private float timeTwo;

    private float oneCurrentBest;

    private float twoCurrentBest;

    // Start is called before the first frame update
    void Start()
    {
        currentLapOne = 0;
        currentLapTwo = 0;
        oneCurrentBest = float.MaxValue;
        twoCurrentBest = float.MaxValue;
        winText.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        timeOne += Time.deltaTime;
        timeTwo += Time.deltaTime;

        //Check input for menu, make sure it can only open one
    }

    public void UpdateText(string pPlayer)
    {
        if (pPlayer == "Player_one")
        {
            currentLapOne++;

            if (currentLapOne == 1)
            {
                player_one_text.SetText($"Lap: {currentLapOne}/{numberOfLaps}\nLast lap:\n--\nBest lap:\n--");
            }
            else
            {
                if (currentLapOne == numberOfLaps + 1)
                {
                    winText.SetText("Player one wins!");
                    winText.color = new Color32(173, 75, 55, 255);
                    winText.enabled = true;
                }
                else
                {
                    if (timeOne < oneCurrentBest)
                    {
                        oneCurrentBest = timeOne;
                    }

                    player_one_text.SetText(
                        $"Lap: {currentLapOne}/{numberOfLaps}\nLast lap:\n{Math.Round(timeOne, 2)}\nBest lap:\n{Math.Round(oneCurrentBest, 2)}");
                }
            }


            timeOne = 0;
        }
        else
        {
            currentLapTwo++;

            if (currentLapTwo == 1)
            {
                player_two_text.SetText($"Lap: {currentLapTwo}/{numberOfLaps}\nLast lap:\n--\nBest lap:\n--");
            }
            else
            {
                if (currentLapTwo == numberOfLaps + 1)
                {
                    winText.SetText("Player two wins!");
                    winText.color = new Color32(52, 65, 147, 255);
                    winText.enabled = true;
                }
                else
                {
                    if (timeTwo < twoCurrentBest)
                    {
                        twoCurrentBest = timeTwo;
                    }

                    player_two_text.SetText(
                        $"Lap: {currentLapTwo}/{numberOfLaps}\nLast lap:\n{Math.Round(timeTwo, 2)}\nBest lap:\n{Math.Round(twoCurrentBest, 2)}");
                }
            }

            timeTwo = 0;
        }
    }
}