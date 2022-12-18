using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TransitionMusic : MonoBehaviour
{
    [SerializeField] private AudioSource musicToChange = null;

    private void OnTriggerEnter(Collider other)
    {
        bool isAPlayer = other.gameObject.CompareTag("Player_one");
        if (isAPlayer)
        {
            ChangeSong();
        }
    }

    private void ChangeSong()
    {
        MusicManager mm = FindObjectOfType<MusicManager>();
        if (mm == null) return;
        if (mm.CurrentSong == null)
        {
            mm.CurrentSong = MusicToChange;
            mm.CurrentSong.mute = false;
return;
        }
mm.CurrentSong.mute = true;
mm.CurrentSong = musicToChange;
mm.CurrentSong.muste = false;
    }
}
