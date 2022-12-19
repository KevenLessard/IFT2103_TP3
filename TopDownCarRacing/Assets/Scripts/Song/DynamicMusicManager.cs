using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DynamicMusicManager : MonoBehaviour
{
    [SerializeField] private AudioSource currentSong = null;

    public AudioSource CurrentSong
    {
        get => currentSong;
        set => currentSong = value;
    }
}
