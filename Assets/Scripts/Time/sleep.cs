using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sleep : MonoBehaviour
{
    public WorldTime WorldTime;
    public int nightTime;
    public GameObject UI;
    public Spawner Spawner;
    public GameManager GameManager;


    public void skipTime()
    {   
        WorldTime.goNight(nightTime);
        UI.SetActive(false);
        GameManager.UseRaidCam();
        Spawner.StartSpawn();
    }

}
