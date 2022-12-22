using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DynamicMusicManager : MonoBehaviour
{
    
    public static DynamicMusicManager Instance;
    
    [SerializeField] private AudioSource currentSong = null;
    [SerializeField] private AudioSource musicToChange1 = null;
    [SerializeField] private AudioSource musicToChange2 = null;
    [SerializeField] private AudioSource musicToChange3 = null;
    [SerializeField] private AudioSource victoryJingle = null;

    public AudioSource[] crowdAudioSourcesArray;
    public AudioSource[] obstacleAudioSourcesArray;
    
    
    public AudioSource ambientSource;
    private void Awake()
    {
        Instance = FindObjectOfType<DynamicMusicManager>();
    }
    
    
    private Slider musicSlider;
    private Slider SFXSlider;
    private Slider ambientSlider;
    public float musicVolume = 1f;
    public float SFXVolume = 1f;
    public float ambientVolume = 1f;
    
    public void SetSliderValues()
    {
        musicSlider = GameObject.Find("MusicVolume").GetComponent<Slider>();
        SFXSlider = GameObject.Find("SFXVolume").GetComponent<Slider>();
        ambientSlider = GameObject.Find("AmbientVolume").GetComponent<Slider>();

        musicSlider.onValueChanged.AddListener(delegate { this.OnMusicVolumeChanged();  });
        SFXSlider.onValueChanged.AddListener(delegate { this.OnSFXVolumeChanged(); });
        ambientSlider.onValueChanged.AddListener(delegate { this.OnAmbientVolumeChanged(); });

        musicSlider.value = musicVolume;
        SFXSlider.value = SFXVolume;
        ambientSlider.value = ambientVolume;
    }
    
    public void OnMusicVolumeChanged()
    {
        SetMusicVolume(musicSlider.value);
    }
    public void OnSFXVolumeChanged()
    {
        SetSFXVolume(SFXSlider.value);
    }
    public void OnAmbientVolumeChanged()
    {
        SetAmbientVolume(ambientSlider.value);
    }
    public void SetMusicVolume(float value)
    {
        musicVolume = value;
        musicToChange1.volume = value;
        musicToChange2.volume = value;
        musicToChange3.volume = value;

    }
    public void SetSFXVolume(float value)
    {
        SFXVolume = value;
        victoryJingle.volume = value;
        if (AudioGoldenSnitch.Instance)
        {
            AudioGoldenSnitch.Instance.setActivateGoldenSnitchVolume(value);
        }
        
        if (Obstacle.Instance)
        {
            foreach (AudioSource audio in obstacleAudioSourcesArray)
            {
                audio.volume = value;
            }
        }
    }
    public void SetAmbientVolume(float value)
    {
        ambientVolume = value;
        ambientSource.volume = value;
        if (AudioGoldenSnitch.Instance)
        {
            AudioGoldenSnitch.Instance.setGoldenSnitchVolume(value);
        }

        if (CrowdVolume.Instance)
        {
            foreach (AudioSource audio in crowdAudioSourcesArray)
            {
                audio.volume = value;
            }
        }
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
