using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioGoldenSnitch : MonoBehaviour
{
    
    [SerializeField] private AudioSource goldenSnitch = null;
    [SerializeField] private AudioSource activateGoldenSnitch = null;
    
    public static AudioGoldenSnitch Instance;
    private void Awake()
    {
        Instance = FindObjectOfType<AudioGoldenSnitch>();
    }

    public void playActivation()
    {
        activateGoldenSnitch.Play();
    }
}
