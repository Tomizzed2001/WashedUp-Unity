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
    public GameManager GameManager;

    [SerializeField] UIManager uiManager;


    public void skipTime()
    {   
        //UI.SetActive(false);
        GameManager.UseRaidCam();
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
        WorldTime.goNight(nightTime);
        yield return new WaitForSeconds(2.5f);
        startSpawn();
    }

}
