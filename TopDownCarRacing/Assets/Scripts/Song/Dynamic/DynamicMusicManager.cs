using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DynamicMusicManager : MonoBehaviour
{
    
    public static DynamicMusicManager Instance;
    
    [SerializeField] private AudioSource currentSong = null;
    [SerializeField] private AudioSource musicToChange1 = null;
    [SerializeField] private AudioSource musicToChange2 = null;
    [SerializeField] private AudioSource musicToChange3 = null;
    [SerializeField] private AudioSource victoryJingle = null;
    public AudioSource ambientSource;
    private void Awake()
    {
        Instance = FindObjectOfType<DynamicMusicManager>();
    }
    
    public AudioSource CurrentSong
    {
        get => currentSong;
        set => currentSong = value;
    }

    public void ChangeSong(int musicNumber)
    {
        if (musicNumber == 2)
        {

            musicToChange1.mute = false;
        }

        else if (musicNumber == 4)
        {        

            musicToChange2.mute = false;
        }

        else if (musicNumber == 6)
        {
            musicToChange1.mute = true;
            musicToChange2.mute = true;
            musicToChange3.mute = false;
        }
        
        else if (musicNumber == 7)
        {
            musicToChange1.mute = true;
            musicToChange2.mute = true;
            musicToChange3.mute = true;
        }

        
    }
    
    public void StartAmbientSong()
    {
        ambientSource.Play();
    }
    
    public void StopAmbientSong()
    {
        ambientSource.Stop();
    }

    public void playVictoryJingle()
    {
        victoryJingle.Play();
    }
}
