using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;


public class RaceLogic : MonoBehaviour
{
    public TextMeshProUGUI player_one_text;
    public TextMeshProUGUI player_two_text;
    public TextMeshProUGUI winText;

    public int numberOfLaps;
    
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
                player_one_text.SetText($"Lap: {currentLapOne}/{numberOfLaps}\nLast lap:\n{Math.Round(timeOne, 2)}\nBest lap:\n{Math.Round(oneCurrentBest, 2)}");
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
                player_two_text.SetText($"Lap: {currentLapTwo}/{numberOfLaps}\nLast lap:\n{Math.Round(timeTwo, 2)}\nBest lap:\n{Math.Round(twoCurrentBest, 2)}");
            }
            timeTwo = 0;
        }
    }
}
