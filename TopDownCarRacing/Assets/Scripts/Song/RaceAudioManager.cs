using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaceAudioManager : MonoBehaviour
{
    public AudioSource musicSource;
    public AudioSource ambientSource;
    public static RaceAudioManager Instance;

    private void Awake()
    {
        Instance = FindObjectOfType<RaceAudioManager>();
    }
    
    public void StartMusic()
    {
        musicSource.Play();
    }

    public void StopMusic()
    {
        musicSource.Stop();
    }

    public void StartAmbientSong()
    {
        ambientSource.Play();
    }
    
    public void StopAmbientSong()
    {
        ambientSource.Stop();
    }
}
