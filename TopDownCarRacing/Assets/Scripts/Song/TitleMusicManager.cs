using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TitleMusicManager : MonoBehaviour
{
    public AudioSource audioSource;
    public AudioClip[] audioClipArray;
    public static TitleMusicManager Instance;
    public AudioSource openingJingle;
    public AudioSource clickingSound;
    
    

    private void Awake()
    {
        Instance = FindObjectOfType<TitleMusicManager>();
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

        musicSlider.onValueChanged.AddListener(delegate { this.OnAmbientVolumeChanged();  });
        SFXSlider.onValueChanged.AddListener(delegate { this.OnEffectVolumeChanged(); });
        ambientSlider.onValueChanged.AddListener(delegate { this.OnFolleyVolumeChanged(); });

        musicSlider.value = musicVolume;
        SFXSlider.value = SFXVolume;
        ambientSlider.value = ambientVolume;
    }
    
    public void OnAmbientVolumeChanged()
    {
        SetAmbientVolume(musicSlider.value);
    }
    public void OnEffectVolumeChanged()
    {
        SetEffectVolume(SFXSlider.value);
    }
    public void OnFolleyVolumeChanged()
    {
        SetFolleyVolume(ambientSlider.value);
    }
    public void SetAmbientVolume(float value)
    {
        musicVolume = value;
        audioSource.volume = value;
    }
    public void SetEffectVolume(float value)
    {
        SFXVolume = value;
        openingJingle.volume = value;
        clickingSound.volume = value;
    }
    public void SetFolleyVolume(float value)
    {
        ambientVolume = value;
    }
    
    public void StartMusic()
    {
        audioSource.PlayOneShot(RandomClip());
    }
    
    AudioClip RandomClip(){
        return audioClipArray[Random.Range(0, audioClipArray.Length)];
    }

    public void playOpeningJingle()
    {
        openingJingle.Play();
    }

    public void playClickingSound()
    {
        clickingSound.Play();
    }
}
