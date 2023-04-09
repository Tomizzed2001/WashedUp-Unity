using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sleep : MonoBehaviour
{
    [Header("Time variables")]
    public TimeManager WorldTime;
    public int nightTime;
    public bool sleptToday;

    [SerializeField] GameObject sleepUI;

    [Header("Managers")]
    [SerializeField] UIManager uiManager;
    [SerializeField] EnemyManager enemyManager;


    public void SkipTime()
    {           
        StartCoroutine(TriggerSpawn());
    }

    public void startSpawn()
    {
        enemyManager.BeginSpawn();
    }

    private IEnumerator TriggerSpawn()
    {
        uiManager.FadeScript.BlackOut();
        yield return new WaitForSeconds(2.5f);
        GameManager.Instance.UseRaidCam();
        WorldTime.goNight(nightTime);
        GameManager.Instance.audioManager.PlayRaid();
        yield return new WaitForSeconds(2.5f);
        startSpawn();
        sleepUI.SetActive(false);
    }

}
