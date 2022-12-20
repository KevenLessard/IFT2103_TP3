using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TransitionMusic : MonoBehaviour
{
    public static TransitionMusic Instance;
    [SerializeField] private AudioSource musicToChange1 = null;
    [SerializeField] private AudioSource musicToChange2 = null;
    [SerializeField] private AudioSource musicToChange3 = null;

    private void Awake()
    {
        Instance = FindObjectOfType<TransitionMusic>();
    }

    private void OnTriggerEnter(Collider other)
    {
        bool isAPlayer = other.gameObject.CompareTag("Player_one");
        if (isAPlayer)
        {
            ChangeSong(1);
        }
    }

    public void ChangeSong(int musicNumber)
    {
        DynamicMusicManager mm = FindObjectOfType<DynamicMusicManager>();
        if (musicNumber == 1)
        {

            mm.CurrentSong.mute = true;
            mm.CurrentSong = musicToChange1;
            mm.CurrentSong.mute = false;
        }

        if (musicNumber == 2)
        {
            mm.CurrentSong.mute = true;
            mm.CurrentSong = musicToChange2;
            mm.CurrentSong.mute = false;
        }

        if (musicNumber == 3)
        {
            mm.CurrentSong.mute = true;
            mm.CurrentSong = musicToChange3;
            mm.CurrentSong.mute = false;
        }
    }
}
