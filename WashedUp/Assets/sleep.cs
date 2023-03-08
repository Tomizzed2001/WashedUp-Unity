using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sleep : MonoBehaviour
{
    public WorldTime WorldTime;
    public int nightTime;
    public GameObject button;


    public void skipTime()
    {
        WorldTime.goNight(nightTime);
        button.SetActive(false);
    }

}
