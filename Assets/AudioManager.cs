using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [SerializeField] AudioSource raidSong;
    [SerializeField] AudioSource beachSong;
    [SerializeField] AudioSource forestSong;
    [SerializeField] AudioSource footstep;

    private bool stepsInProgress;

    private void Start()
    {
        PlayBeach();
    }


    public void PlayRaid()
    {
        StartCoroutine(FadeAudioIn(raidSong, 100));
    }

    public void FadeRaid()
    {
        StartCoroutine(FadeAudioOut(raidSong));
    }

    public void PlayBeach()
    {
        StartCoroutine(FadeAudioIn(beachSong, 20));
    }

    public void FadeBeach()
    {
        StartCoroutine(FadeAudioOut(beachSong));
    }

    public void PlayForest()
    {
        StartCoroutine(FadeAudioIn(forestSong, 20));
    }

    public void FadeForest()
    {
        StartCoroutine(FadeAudioOut(forestSong));
    }

    public void FootStep(bool isWalking)
    {
        if (isWalking)
        {
            if (stepsInProgress)
            {
                return;
            }
            stepsInProgress = true;
            footstep.loop = true;
            footstep.Play();
        }
        else
        {
            stepsInProgress = false;
            footstep.loop = false;
        }
    }

    private IEnumerator FadeAudioIn(AudioSource audio, int volume)
    {
        audio.volume = 0;
        audio.Play();
        
        for (int i = 0; i < volume; i++)
        {
            yield return new WaitForSeconds(0.2f);
            audio.volume += 0.01f;
        }
        
    }

    private IEnumerator FadeAudioOut(AudioSource audio)
    {
        float volume = audio.volume;

        for (float i = volume; i > 0; i -= 0.01f)
        {
            yield return new WaitForSeconds(0.2f);
            i = audio.volume;
            audio.volume -= 0.01f;
        }

    }
}
