using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldTime : MonoBehaviour
{
    [SerializeField] float dayLength;
    [SerializeField] int startTime;
    [SerializeField] public TimeSpan currentTime;

    [SerializeField] TimeDisplay timeDisplay;
    [SerializeField] DayLight daylight;

    private float timeLength => dayLength / 1440;

    private void Start()
    {
        currentTime = TimeSpan.FromMinutes(startTime);
        StartCoroutine(AddMinute());
    }

    public void goNight(int nightTime)
    {
        currentTime = TimeSpan.FromMinutes(nightTime);

    }

    private IEnumerator AddMinute()
    {
        currentTime += TimeSpan.FromMinutes(1);
        timeDisplay.timer = currentTime;
        timeDisplay.UpdateTime();
        daylight.UpdateLights();
        yield return new WaitForSeconds(timeLength);
        StartCoroutine(AddMinute());
    }
}
