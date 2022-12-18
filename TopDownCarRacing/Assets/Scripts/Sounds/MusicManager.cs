using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicManager : MonoBehaviour
{
    [SerializedField] private AudioSource currentSong = null;

    public AudioSource CurrentSong
    {
        get => currentSong;
        set => currentSong = value;
    }
}
