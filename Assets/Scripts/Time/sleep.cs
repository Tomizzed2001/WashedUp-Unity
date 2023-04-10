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


    public void SkipTime()
    {           
        StartCoroutine(WorldTime.TriggerSpawn());
    }

}
