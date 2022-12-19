using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TitleMusicManager : MonoBehaviour
{
    public AudioSource audioSource;
    public static TitleMusicManager Instance;

    private void Awake()
    {
        Instance = FindObjectOfType<TitleMusicManager>();
    }
    
    public void StartMusic()
    {
        audioSource.Play();
    }
}
