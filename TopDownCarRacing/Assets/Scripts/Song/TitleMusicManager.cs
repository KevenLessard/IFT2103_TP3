using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TitleMusicManager : MonoBehaviour
{
    public AudioSource audioSource;
    public AudioClip[] audioClipArray;
    public static TitleMusicManager Instance;
    public AudioSource openingJingle;

    private void Awake()
    {
        Instance = FindObjectOfType<TitleMusicManager>();
    }
    
    public void StartMusic()
    {
        //audioSource.Play();
        audioSource.PlayOneShot(RandomClip());
    }
    
    AudioClip RandomClip(){
        return audioClipArray[Random.Range(0, audioClipArray.Length)];
    }

    public void playOpeningJingle()
    {
        openingJingle.Play();
    }
}
