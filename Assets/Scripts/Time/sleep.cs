using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sleep : MonoBehaviour
{
    public TimeManager WorldTime;
    public int nightTime;
    public GameObject UI;
    private Spawner Spawner;
    public bool sleptToday;

    [SerializeField] UIManager uiManager;


    public void skipTime()
    {           
        StartCoroutine(TriggerSpawn());
    }

    public void startSpawn()
    {
        foreach (var spawner in GameObject.FindGameObjectsWithTag("Spawner"))
        {
            Spawner = spawner.GetComponent<Spawner>();
            Spawner.StartSpawn();
        }
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
        gameObject.SetActive(false);
    }

}
