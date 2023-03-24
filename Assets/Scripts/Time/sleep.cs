using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sleep : MonoBehaviour
{
    public WorldTime WorldTime;
    public int nightTime;
    public GameObject UI;
    private Spawner Spawner;
    public GameManager GameManager;


    public void skipTime()
    {   
        WorldTime.goNight(nightTime);
        UI.SetActive(false);
        GameManager.UseRaidCam();
        startSpawn();
    }

    public void startSpawn()
    {
        foreach (var spawner in GameObject.FindGameObjectsWithTag("Spawner"))
        {
            Spawner = spawner.GetComponent<Spawner>();
            Spawner.StartSpawn();
        }
    }

}
