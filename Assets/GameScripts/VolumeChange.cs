using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VolumeChange : MonoBehaviour
{
    private AudioSource sound;
    private float musicvolume = 1f;
    private void Start()
    {
        sound = GetComponent<AudioSource>();
    }

    private void Update()
    {
        sound.volume = musicvolume;
    }

    public void setVolume(float vol)
    {
        musicvolume = vol;
    }
}
