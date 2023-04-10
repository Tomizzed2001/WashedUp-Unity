using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [Header("Audio Sources")]
    [SerializeField] AudioSource raidSong;
    [SerializeField] AudioSource beachSong;
    [SerializeField] AudioSource forestSong;
    [SerializeField] AudioSource footstep;
    [SerializeField] AudioSource tree;
    [SerializeField] AudioSource stone;
    [SerializeField] AudioSource slingshot;
    [SerializeField] AudioSource objective;
    [SerializeField] AudioSource barrel;
    [SerializeField] AudioSource bow;
    [SerializeField] AudioSource noAmmo;
    [SerializeField] AudioSource gameWin;
    [SerializeField] AudioSource gameLose;

    private bool stepsInProgress;

    private void Start()
    {
        PlayBeach();
        PlayForest();
        forestSong.Stop();
    }

    //Raid
    public void PlayRaid()
    {
        StartCoroutine(FadeAudioIn(raidSong, 50));
    }

    public void FadeRaid()
    {
        StartCoroutine(FadeAudioOut(raidSong));
    }

    public void StopRaid()
    {
        raidSong.Stop();
    }

    //Beach
    public void PlayBeach()
    {
        StartCoroutine(FadeAudioIn(beachSong, 20));
    }

    public void FadeBeach()
    {
        StartCoroutine(FadeAudioOut(beachSong));
    }

    //Forest
    public void PlayForest()
    {
        StartCoroutine(FadeAudioIn(forestSong, 20));
    }

    public void FadeForest()
    {
        StartCoroutine(FadeAudioOut(forestSong));
    }

    //Player
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
            footstep.Stop();
        }
    }

    public void Objecive()
    {
        objective.Play();
    }

    public void TreeChop()
    {
        tree.Play();
    }

    public void StoneHit()
    {
        stone.Play();
    }

    public void BarrelHit()
    {
        barrel.Play();
    }

    public void Slingshot()
    {
        slingshot.Play();
    }

    public void Bow()
    {
        bow.Play();
    }

    public void NoAmmo()
    {
        noAmmo.Play();
    }

    public void GameWin()
    {
        gameWin.Play();
    }

    public void GameLose()
    {
        gameLose.Play();
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
