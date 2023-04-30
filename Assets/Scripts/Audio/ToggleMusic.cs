using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToggleMusic : MonoBehaviour
{
    [SerializeField] AudioSource music;

    private bool musicPlaying = true;
    public void toggle()
    {
        if (musicPlaying)
        {
            music.volume = 0;
            musicPlaying = false;
        }
        else
        {
            music.volume = 1;
            musicPlaying = true;
        }
    }
}
