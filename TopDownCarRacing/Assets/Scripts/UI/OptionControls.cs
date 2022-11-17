using System;
using System.Collections;
using TMPro;
using UnityEngine;

public class OptionControls : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI forwardText;
    [SerializeField]
    private TextMeshProUGUI backwardText;
    [SerializeField]
    private TextMeshProUGUI leftText;
    [SerializeField]
    private TextMeshProUGUI rightText;

    [SerializeField] private Inputs inputs;

    void Start()
    {
        forwardText.text = inputs._playerInputs[0].ToString();
        backwardText.text = inputs._playerInputs[1].ToString();
        leftText.text = inputs._playerInputs[2].ToString();
        rightText.text = inputs._playerInputs[3].ToString();
    }

    public void OnForwardUpdateClick()
    {
        KeyCode newInput;
        StartCoroutine(waitForKeyPress(newKey =>
        {
            newInput = newKey;
            if (newInput != KeyCode.Escape)
                inputs._playerInputs[0] = newInput;
            forwardText.text = newInput.ToString();
        }));
    }
    
    public void OnBackwardUpdateClick()
    {
        KeyCode newInput;
        StartCoroutine(waitForKeyPress(newKey =>
        {
            newInput = newKey;
            if (newInput != KeyCode.Escape)
                inputs._playerInputs[1] = newInput;
            backwardText.text = newInput.ToString();
        }));
    }
    
    public void OnLeftUpdateClick()
    {
        KeyCode newInput;
        StartCoroutine(waitForKeyPress(newKey =>
        {
            newInput = newKey;
            if (newInput != KeyCode.Escape)
                inputs._playerInputs[2] = newInput;
            leftText.text = newInput.ToString();
        }));
    }
    
    public void OnRightUpdateClick()
    {
        KeyCode newInput;
        StartCoroutine(waitForKeyPress(newKey =>
        {
            newInput = newKey;
            if (newInput != KeyCode.Escape)
                inputs._playerInputs[3] = newInput;
            rightText.text = newInput.ToString();
        }));
    }

    private IEnumerator waitForKeyPress(Action<KeyCode> callback)
    {
        //Trash value
        KeyCode key = KeyCode.UpArrow;
        bool done = false;
        while (!done)
        {
            if (Input.anyKeyDown)
            {
                foreach(KeyCode kcode in Enum.GetValues(typeof(KeyCode)))
                {
                    if (Input.GetKey(kcode))
                    {
                        if (kcode != KeyCode.Escape)
                            key = kcode;
                    }
                }
                done = true;
            }
            yield return null;
        }
        callback(key);
    }
}
